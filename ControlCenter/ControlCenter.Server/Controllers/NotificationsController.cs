using System.Collections.Generic;
using System.Threading.Tasks;
using ControlCenter.BL.Queries.Notifications;
using ControlCenter.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : Controller
    {
        #region Commands and Queries

        private readonly GetNotificationsQuery getNotificationsQuery;

        #endregion Commands and Queries

        #region Constructor

        public NotificationsController(GetNotificationsQuery getNotificationsQuery)
        {
            this.getNotificationsQuery = getNotificationsQuery;
        }

        #endregion Constructor

        #region Actions

        [HttpGet]
        [Route("GetNotifications")]
        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await getNotificationsQuery.Execute();
        }

        #endregion Actions
    }
}
