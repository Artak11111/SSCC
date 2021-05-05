using System;
using System.Threading.Tasks;
using ControlCenter.BL.Commands.Notifications;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Queries.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NotificationsController : Controller
    {
        #region Commands and Queries

        private readonly GetNotificationsQuery getNotificationsQuery;
        private readonly GetNewNotificationsQuery getNewNotificationsQuery;
        private readonly CheckForNewNotificationsQuery checkForNewNotificationsQuery;
        private readonly CreateNotificationCommand createNotificationCommand;
        private readonly MarkNotificationAsSeenCommand markNotificationAsSeenCommand;
        private readonly TaskExecutor.TaskExecutor taskExecutor;

        #endregion Commands and Queries

        #region Constructor

        public NotificationsController(CreateNotificationCommand createNotificationCommand, MarkNotificationAsSeenCommand markNotificationAsSeenCommand, GetNotificationsQuery getNotificationsQuery, TaskExecutor.TaskExecutor taskExecutor)
        {
            this.getNotificationsQuery = getNotificationsQuery;
            this.createNotificationCommand = createNotificationCommand;
            this.markNotificationAsSeenCommand = markNotificationAsSeenCommand;
            this.taskExecutor = taskExecutor;
        }

        #endregion Constructor

        #region Actions

        [HttpGet]
        [Route("GetNotifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var result = await taskExecutor.Execute(async () =>
            {
                return await getNotificationsQuery.Execute();
            });

            if (result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("GetNewNotifications")]
        public async Task<IActionResult> GetNewNotifications()
        {
            var result = await taskExecutor.Execute(async () =>
            {
                return await getNewNotificationsQuery.Execute();
            });

            if (result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("CheckForNewNotifications")]
        public async Task<IActionResult> CheckForNewNotifications()
        {
            var result = await taskExecutor.Execute(async () =>
            {
                return await checkForNewNotificationsQuery.Execute();
            });

            if (result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Route("MarkNotificationAsSeen")]
        public async Task<IActionResult> MarkNotificationAsSeen(Guid noticitationId)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                await markNotificationAsSeenCommand.Execute(noticitationId);
            });

            if (result.ErrorMessage == null)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Route("CreateNotification")]
        public async Task<IActionResult> CreateNotification([FromBody]CreateNotificationInputModel input)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                await createNotificationCommand.Execute(input);
            });

            if (result.ErrorMessage == null)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessage);
        }

        #endregion Actions
    }
}
