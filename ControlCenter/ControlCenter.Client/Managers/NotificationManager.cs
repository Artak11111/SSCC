using ControlCenter.Client.Client;
using ControlCenter.Client.Managers.Models;
using ControlCenter.Client.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ControlCenter.Client.Managers
{
    public class NotificationManager
    {
        #region Fields

        private readonly ApiClient client;
        private readonly NotificationService notificationService;

        //endpoints

        private const string ControllerName = "Notifications";

        private readonly string GetNotificationsUrl = $"{ControllerName}/GetNotifications";
        private readonly string GetNewNotificationsUrl = $"{ControllerName}/GetNewNotifications";
        private readonly string CheckForNewNotificationsUrl = $"{ControllerName}/CheckForNewNotifications";

        private readonly string MarkNotificationAsSeenUrl = $"{ControllerName}/MarkNotificationAsSeen";
        private readonly string CreateNotificationUrl = $"{ControllerName}/CreateNotification";

        #endregion Fields

        #region Constructor

        public NotificationManager(ApiClient client, NotificationService notificationService)
        {
            this.client = client;
            this.notificationService = notificationService;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<UserNotification>> GetNotifications()
        {
            var response = await client.SendAsync<List<UserNotification>>(HttpMethod.Get, GetNotificationsUrl);

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return null;
            }

            return response.Result;
        }

        public async Task<List<UserNotification>> GetNewNotifications()
        {
            var response = await client.SendAsync<List<UserNotification>>(HttpMethod.Get, GetNewNotificationsUrl);

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return null;
            }

            return response.Result;
        }

        public async Task<bool?> CheckForNewNotifications()
        {
            var response = await client.SendAsync<bool>(HttpMethod.Get, CheckForNewNotificationsUrl);

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return null;
            }

            return response.Result;
        }

        public async Task MarkNotificationAsSeen(Guid noticitationId)
        {
            var response = await client.SendAsync(HttpMethod.Post, $"{MarkNotificationAsSeenUrl}?noticitationId={noticitationId}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
            }
        }

        public async Task<bool> CreateNotification(CreateNotificationInputModel input)
        {
            var response = await client.SendAsync(HttpMethod.Post, $"{CreateNotificationUrl}?input={JsonConvert.SerializeObject(input)}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);

                return false;
            }

            return true;
        }

        #endregion Methods
    }
}
