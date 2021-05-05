using Autofac;
using ControlCenter.Client.ViewModels;

namespace ControlCenter.Client.ServiceLocators
{
    public class ViewModelLocator
    {
        public static SignInViewModel SignInViewModel => ServiceLocator.Container.Resolve<SignInViewModel>();

        public static SignUpViewModel SignUpViewModel => ServiceLocator.Container.Resolve<SignUpViewModel>();

        public static DashboardViewModel DashboardViewModel => ServiceLocator.Container.Resolve<DashboardViewModel>();
    }
}
