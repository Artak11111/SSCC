using Autofac;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Regions;
using System.Windows.Controls;

namespace ControlCenter.Client.Views
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();

            Loaded += Dashboard_Initialized;
        }

        private void Dashboard_Initialized(object sender, System.EventArgs e)
        {
            var navigationManager = ServiceLocators.ServiceLocator.Container.Resolve<NavigationManager>();
            navigationManager.RegisterRegion(RegionNames.Dashboard, dashboardContent);
        }
    }
}
