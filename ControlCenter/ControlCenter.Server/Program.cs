using ControlCenter.BL.UserInfoProvider;
using ControlCenter.Contracts.Contracts;
using ControlCenter.DB;
using ControlCenter.Server.Jobs;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using Microsoft.IdentityModel.Tokens;
using ControlCenter.BL.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ControlCenter.Server.Middlewares;
using Microsoft.Extensions.Configuration;
using ControlCenter.BL.Queries.Users;
using ControlCenter.BL.Commands.Users;
using ControlCenter.BL.Commands.Notifications;
using ControlCenter.BL.Commands.Departments;
using ControlCenter.BL.Queries.Departments;
using ControlCenter.BL.Queries.Notifications;

namespace ControlCenter.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            var app = builder.Build();

            //register application jobs
            ConfigureApplicationJobs(app.Services);

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControlCenter.Server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // adding custom middleware for capturing authtorized user information in IUserInfoProvider
            app.UseUserInfoProviderSetter();

            app.MapControllers();

            app.Run();
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var services = builder.Services;

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
            services.AddDbContext<ControlCenterDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            // adding scoped services
            services.AddScoped<ChangeDepartmentCommand>();
            services.AddScoped<CreateNotificationCommand>();
            services.AddScoped<MarkNotificationAsSeenCommand>();
            services.AddScoped<ChangeDepartmentStatusCommand>();
            services.AddScoped<ChangePasswordCommand>();
            services.AddScoped<AuthenticateUserCommand>();
            services.AddScoped<GetDepartmentsQuery>();
            services.AddScoped<GetDisabledDepartmentsQuery>();
            services.AddScoped<CheckForNewNotificationsQuery>();
            services.AddScoped<GetNewNotificationsQuery>();
            services.AddScoped<GetNotificationsQuery>();
            services.AddScoped<GetUsersQuery>();
            services.AddScoped<NotificationSenderJob>();
            services.AddScoped<IUserInfoProvider, UserInfoProvider>();
            services.AddSingleton<IJobManager, JobManager>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions.MaxDepth = 10000);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlCenter.Server", Version = "v1" });
            });
        }

        private static void ConfigureApplicationJobs(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var jobManager = scope.ServiceProvider.GetService<IJobManager>();
                var notificationSenderJob = scope.ServiceProvider.GetService<NotificationSenderJob>();

                jobManager.Create(NotificationSenderJob.Key, 5, notificationSenderJob.Execute);
            }
        }
    }
}
