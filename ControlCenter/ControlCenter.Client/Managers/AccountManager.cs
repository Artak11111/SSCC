using ControlCenter.Client.Client;
using ControlCenter.Client.Sequrity;
using ControlCenter.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ControlCenter.Client.Managers.Models;
using System.Collections.Generic;

namespace ControlCenter.Client.Managers
{
    public class AccountManager
    {
        #region Fields

        private readonly ApiClient client;
        private readonly NotificationService notificationService;
        private readonly UserSession.UserSession userSession;

        //endpoints

        private const string ControllerName = "Account";

        private readonly string SignInUrl = $"{ControllerName}/sign-in";
        private readonly string ChangePasswordUrl = $"{ControllerName}/change-password";
        private readonly string ChangeDepartmentUrl = $"{ControllerName}/change-department";
        private readonly string GetUsersUrl = $"{ControllerName}/get-users";

        #endregion Fields

        #region Constructor

        public AccountManager(ApiClient client, UserSession.UserSession userSession, NotificationService notificationService)
        {
            this.client = client;
            this.notificationService = notificationService;
            this.userSession = userSession;
        }

        #endregion Constructor

        #region Methods

        public async Task<bool> SignIn(string email, string password)
        {
            var passwordHash = string.IsNullOrEmpty(password) ? string.Empty : Cryptography.GetPasswordHash(password);
            var response = await client.SendAsync<SignInResult>(HttpMethod.Post, $"{SignInUrl}?email={email}&passwordHash={passwordHash}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return false;
            }

            userSession.StartSession(response.Result);
            client.AddAuthentication(response.Result.Token);

            return true;
        }

        public void SignOut()
        {
            userSession.EndSession();
        }

        public async Task<bool> ChangePassword(string oldPassword, string newPassword)
        {
            var oldPasswordHash = string.IsNullOrEmpty(oldPassword) ? string.Empty : Cryptography.GetPasswordHash(oldPassword);
            var response = await client.SendAsync(HttpMethod.Post, $"{ChangePasswordUrl}?oldasswordHash={oldPasswordHash}&newPasswordHash={Cryptography.GetPasswordHash(newPassword)}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);

                return false;
            }

            return true;
        }

        public async Task<bool> ChangeDepartment(Guid userId, Guid newDepartmentId)
        {
            var response = await client.SendAsync(HttpMethod.Post, $"{ChangeDepartmentUrl}?userId={userId}&departmentId={newDepartmentId}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return false;
            }

            return true;
        }


        public async Task<List<User>> GetUsers()
        {
            var response = await client.SendAsync<List<User>>(HttpMethod.Get, GetUsersUrl);

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return null;
            }

            return response.Result;
        }

        #endregion Methods
    }
}
