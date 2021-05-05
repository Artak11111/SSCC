using Autofac;
using ControlCenter.Client.Client;
using ControlCenter.Client.Helpers;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.ServiceLocators;
using System.Linq;

namespace ControlCenter.Client
{
    public partial class App
    {
        #region Constructor

        public App()
        {
            OperationsHelper.RunParallel(Initialize);
        }

        #endregion Constructor

        #region Methods


        #region Private Methods

        private void InitializeShell()
        {
            var window = new Shell();
            window.Show();
        }

        private void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new NavigationManager())
                .As<INavigationManager>();

            builder.RegisterType<ApiClient>()
                .SingleInstance();

            builder.RegisterType<UserSession.UserSession>()
                .SingleInstance();

            RegisterViewModels(builder);
            RegisterManagers(builder);
            RegisterServices(builder);

            ServiceLocator.Initialize(builder.Build());

            UIThreadHelper.AccessUIThread(InitializeShell);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            foreach (var type in this.GetType().Assembly.GetTypes().Where(t => t.Namespace == "ControlCenter.Client.Services" && t.Name.EndsWith("Service")))
            {
                builder.RegisterType(type)
                    .SingleInstance();
            }
        }

        private void RegisterManagers(ContainerBuilder builder)
        {
            foreach (var type in this.GetType().Assembly.GetTypes().Where(t => t.Namespace == "ControlCenter.Client.Managers" && t.Name.EndsWith("Manager")))
            {
                builder.RegisterType(type)
                    .SingleInstance();
            }
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            foreach (var type in this.GetType().Assembly.GetTypes().Where(t => t.Namespace == "ControlCenter.Client.ViewModels" && t.Name.EndsWith("ViewModel")))
            {
                builder.RegisterType(type)
                    .InstancePerDependency();
            }
        }

        #endregion Private Methods

        #endregion Methods
    }
}