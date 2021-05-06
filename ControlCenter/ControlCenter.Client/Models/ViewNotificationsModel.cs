using ControlCenter.Client.Managers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter.Client.Models
{
    public class ViewNotificationsModel : BindableBase
    {
        #region Properties

        public List<UserNotification> Notifications { get; set; }

        #endregion Properties
    }
}
