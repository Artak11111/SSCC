using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ControlCenter.Abstractions;
using ControlCenter.BL.UserInfoProvider;
using ControlCenter.DB;
using ControlCenter.Server.Middlewares;
using ControlCenter.Server.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ControlCenter.Server.Jobs;
using System.Threading.Tasks;

namespace ControlCenter.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // adding authentiction
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,

                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            // adding db context 
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]),
                ServiceLifetime.Transient);


            // adding scoped services
            services.AddScoped<NotificationSenderJob>();
            services.AddScoped<TaskExecutor.TaskExecutor>();
            services.AddScoped<IUserInfoProvider, UserInfoProvider>();
            services.AddSingleton<IJobManager, JobManager>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllers()
                .AddJsonOptions(o=> o.JsonSerializerOptions.MaxDepth = 10000);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ControlCenter.Server", Version = "v1"});
            });

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyModules(typeof(Startup).Assembly);

            containerBuilder.Populate(services);
            ApplicationContainer = containerBuilder.Build();

            var serviceProvider = new AutofacServiceProvider(ApplicationContainer);

            //register application jobs
            ConfigureApplicationJobs(serviceProvider);

            return serviceProvider;
        }

        private void ConfigureApplicationJobs(IServiceProvider serviceProvider)
        {
            var jobManager = serviceProvider.GetService<IJobManager>();
            var notificationSenderJob = serviceProvider.GetService<NotificationSenderJob>();

            jobManager.CreateJob(NotificationSenderJob.Key, 5, notificationSenderJob.Execute);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControlCenter.Server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // adding custom middleware for capturing authtorized user information in IUserInfoProvider
            app.UseUserInfoProviderSetter();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}