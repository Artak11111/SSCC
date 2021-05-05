using System.Windows.Controls;

namespace ControlCenter.Client.Navigation
{
    public interface INavigationManager
    {
        void RegisterRegion(string name, ContentControl container);

        void RemoveRegion(string regionName);

        void RequestNavigate<T>(string regionName = "MainRegion")
            where T : new();

        bool NavigateBack(string regionName = "MainRegion");
    }
}
