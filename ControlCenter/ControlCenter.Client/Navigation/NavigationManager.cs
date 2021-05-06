using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ControlCenter.Client.Navigation
{
    public class NavigationManager
    {
        #region Fields

        private readonly Dictionary<string, ContentControl> regions = new Dictionary<string, ContentControl>();
        private readonly Dictionary<string, List<UserControl>> navigationHistory = new Dictionary<string, List<UserControl>>();

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

            if (regions.ContainsKey(regionName))
            {
                regions[regionName] = container;
                navigationHistory[regionName] = new List<UserControl>();

                return;
            }

            regions.Add(regionName, container);

            navigationHistory.Add(regionName, new List<UserControl>());
        }

        public void RemoveRegion(string regionName)
        {
            if (string.IsNullOrEmpty(regionName)) throw new ArgumentNullException(nameof(regionName));

            if (!regions.ContainsKey(regionName)) return;

            regions.Remove(regionName);
            navigationHistory.Remove(regionName);
        }

        public void RequestNavigate<T>(string regionName = "MainRegion")
            where T : new()
        {
            if (string.IsNullOrEmpty(regionName)) throw new ArgumentNullException(nameof(regionName));

            if (!regions.ContainsKey(regionName))
                throw new InvalidOperationException("Region doesn't exist");

            regions[regionName].Content = new T();
            navigationHistory[regionName].Add(regions[regionName].Content as UserControl);
        }

        public bool NavigateBack(string regionName = "MainRegion")
        {
            if (string.IsNullOrEmpty(regionName)) 
                throw new ArgumentNullException(nameof(regionName));

            if(!regions.ContainsKey(regionName))
                throw new InvalidOperationException("Region doesn't exist");

            if (navigationHistory[regionName].Count < 1)
                return false;

            navigationHistory[regionName].Remove(navigationHistory[regionName].Last());

            regions[regionName].Content = navigationHistory[regionName].LastOrDefault();

            return true;
        }

        public bool CanNavigateBack(string regionName = "MainRegion")
        {
            if (string.IsNullOrEmpty(regionName))
                throw new ArgumentNullException(nameof(regionName));

            if (!regions.ContainsKey(regionName))
                return false;

            if (navigationHistory[regionName].Count < 1)
                return false;

            return true;
        }

        #endregion Manager
    }
}
