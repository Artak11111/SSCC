using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ControlCenter.Client.Navigation
{
    public interface INavigationManager
    {
        void RegisterRegion(string name, ContentControl container);

        void RequestNavigate<T>(string regionName)
            where T : new();
    }
}
