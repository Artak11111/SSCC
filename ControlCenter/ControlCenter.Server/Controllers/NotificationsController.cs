using System;
using System.Threading.Tasks;
using ControlCenter.BL.Commands.Notifications;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Queries.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        #region Commands and Queries

        private readonly GetNotificationsQuery GetNotificationsQuery;
        private readonly GetNewNotificationsQuery GetNewNotificationsQuery;
        private readonly CheckForNewNotificationsQuery CheckForNewNotificationsQuery;
        private readonly CreateNotificationCommand CreateNotificationCommand;
        private readonly MarkNotificationAsSeenCommand MarkNotificationAsSeenCommand;

        #endregion Commands and Queries

        #region Constructor

        public NotificationsController(GetNewNotificationsQuery getNewNotificationsQuery, 
            CheckForNewNotificationsQuery checkForNewNotificationsQuery, 
            CreateNotificationCommand createNotificationCommand, 
            MarkNotificationAsSeenCommand markNotificationAsSeenCommand, 
            GetNotificationsQuery getNotificationsQuery)
        {
            GetNotificationsQuery = getNotificationsQuery;
            GetNewNotificationsQuery = getNewNotificationsQuery;
            CreateNotificationCommand = createNotificationCommand;
            MarkNotificationAsSeenCommand = markNotificationAsSeenCommand;
            CheckForNewNotificationsQuery = checkForNewNotificationsQuery;
        }

        #endregion Constructor

        #region Actions

        [HttpGet]
        [Route("get-notifications")]
        public Task<IActionResult> GetNotifications()
        {
            return Run(GetNotificationsQuery);
        }

        [HttpGet]
        [Route("get-new-notifications")]
        public Task<IActionResult> GetNewNotifications()
        {
            return Run(GetNewNotificationsQuery);
        }

        [HttpGet]
        [Route("check-for-new-notifications")]
        public Task<IActionResult> CheckForNewNotifications()
        {
            return Run(CheckForNewNotificationsQuery);
        }

        [HttpPost]
        [Route("mark-notification-as-seen")]
        public Task<IActionResult> MarkNotificationAsSeen(Guid noticitationId)
        {
            return Run(MarkNotificationAsSeenCommand, noticitationId);
        }

        [HttpPost]
        [Route("create-notification")]
        public Task<IActionResult> CreateNotification(string input)
        {
            return Run(CreateNotificationCommand, JsonConvert.DeserializeObject<CreateNotificationInputModel>(input));
        }

        #endregion Actions
    }
}
