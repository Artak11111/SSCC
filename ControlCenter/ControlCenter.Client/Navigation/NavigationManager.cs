using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ControlCenter.Client.Navigation
{
    public class NavigationManager : INavigationManager
    {
        #region Fields

        private readonly Dictionary<string, ContentControl> regions = new Dictionary<string, ContentControl>();

        #endregion Fields

        #region Constructor

        public NavigationManager()
        {
        }

        #endregion Constructor

        #region Manager

        public void RegisterRegion(string regionName, ContentControl container)
        {
            if (string.IsNullOrEmpty(regionName)) throw new ArgumentNullException(nameof(regionName));
            if (container == null) throw new ArgumentNullException(nameof(container));

            if (regions.ContainsKey(regionName)) return;

            regions.Add(regionName, container);
        }

        public void RequestNavigate<T>(string regionName)
            where T : new()
        {
            if (string.IsNullOrEmpty(regionName)) throw new ArgumentNullException(nameof(regionName));

            if (!regions.ContainsKey(regionName))
                throw new InvalidOperationException("Region doesn't exist");

            regions[regionName].Content = new T();
        }

        #endregion Manager
    }
}
