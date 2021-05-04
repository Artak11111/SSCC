using Autofac;
using ControlCenter.BL.UserInfoProvider;
using System.Reflection;

namespace ControlCenter.Server.AutofacModules
{
    public class BusinessLogicModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(Assembly.GetAssembly(typeof(UserInfoProvider)))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }

}
