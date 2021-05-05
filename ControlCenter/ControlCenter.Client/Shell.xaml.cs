using Autofac;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Regions;
using ControlCenter.Client.Views;
using System.Windows;

namespace ControlCenter.Client
{
    public partial class Shell
    {
        public Shell()
        {
            InitializeComponent();

            Loaded += Shell_Initialized;
        }

        private void Shell_Initialized(object sender, System.EventArgs e)
        {
            var navigationManager = ServiceLocators.ServiceLocator.Container.Resolve<NavigationManager>();
            navigationManager.RegisterRegion(RegionNames.Main, content);

            navigationManager.RequestNavigate<SignIn>(RegionNames.Main);
        }

        private void content_ContentChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            DataContext = (content.Content as FrameworkElement)?.DataContext;

            content.ContentChanged += (s, args) =>
            {
                DataContext = (content.Content as FrameworkElement)?.DataContext;
            };
        }
    }
}
