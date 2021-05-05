using ControlCenter.Client.Client;
using ControlCenter.Client.Sequrity;
using ControlCenter.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ControlCenter.Client.Managers.Models;

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

        private readonly string SignInUrl = $"{ControllerName}/SignIn";
        private readonly string ChangePasswordUrl = $"{ControllerName}/ChangePassword";
        private readonly string ChangeDepartmentUrl = $"{ControllerName}/ChangeDepartment";

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

        public async Task ChangePassword(string oldPassword, string newPassword)
        {
            var oldPasswordHash = string.IsNullOrEmpty(oldPassword) ? string.Empty : Cryptography.GetPasswordHash(oldPassword);
            var response = await client.SendAsync(HttpMethod.Post, $"{ChangePasswordUrl}?oldasswordHash={oldPasswordHash}&newPasswordHash={Cryptography.GetPasswordHash(newPassword)}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
            }
        }

        public async Task ChangeDepartment(Guid userId, Guid newDepartmentId)
        {
            var response = await client.SendAsync(HttpMethod.Post, $"{ChangeDepartmentUrl}?userId={userSession.UserId}&newDepartmentId={newDepartmentId}");

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
            }
        }

        #endregion Methods
    }
}
