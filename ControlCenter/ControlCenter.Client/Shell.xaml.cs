using ControlCenter.Client.Navigation;
using ControlCenter.Client.Regions;
using ControlCenter.Client.Views;
using System.Windows;

namespace ControlCenter.Client
{
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();

            Loaded += Shell_Initialized;
        }

        private void Shell_Initialized(object sender, System.EventArgs e)
        {
            var navigationManager = new NavigationManager();
            navigationManager.RegisterRegion(RegionNames.Main, content);

            Dispatcher.Invoke(() => 
            {
                navigationManager.RequestNavigate<SignIn>(RegionNames.Main);
            });
        }
    }
}
