using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter.Client.Navigation
{
    public interface INavigationManager
    {
        void RequestNavigate<T>(string regionName)
            where T : new();
    }
}
