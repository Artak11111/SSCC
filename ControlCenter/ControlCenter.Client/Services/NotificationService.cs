using ControlCenter.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControlCenter.Client.Services
{
    public class NotificationService
    {
        public void ShowError(string message)
        {
            UIThreadHelper.AccessUIThread(()=> MessageBox.Show(message));
        }
    }
}
