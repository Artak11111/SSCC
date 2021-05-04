using Autofac;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Regions;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ControlCenter.Client
{
    public partial class App
    {
        #region Constructor

        public App()
        {
            Initialize();

            var window = new Shell();
            window.Show();
        }

        #endregion Constructor

        #region Properties

        public IContainer Container { get; set; }

        #endregion Properties

        #region Methods


        #region Private Methods

        private async void Initialize()
        {
            Container = await Task.Run(() => 
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance<INavigationManager>(new NavigationManager());

                return builder.Build();
            });
        }

        #endregion Private Methods

        #endregion Methods
    }
}