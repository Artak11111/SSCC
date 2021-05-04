using ControlCenter.Client.Client;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace ControlCenter.Client.Managers
{
    public class AccountManager
    {
        #region Fields

        private readonly ApiClient client;

        //endpoints

        private const string ControllerName = "Account";

        private readonly string SignInUrl = $"{ControllerName}/SignIn";
        private readonly string ChangePasswordUrl = $"{ControllerName}/ChangePassword";

        #endregion Fields

        #region Constructor

        public AccountManager(ApiClient client)
        {
            this.client = client;
        }

        #endregion Constructor

        #region Methods

        public async Task SignIn(string email, string password)
        {
            var result = await client.SendAsync<string>(HttpMethod.Post, $"{SignInUrl}?email={email}&passwordHash={password}");

            client.AddAuthentication(result.Result);

            var req = await client.SendAsync(HttpMethod.Post, $"{ChangePasswordUrl}?userId=18937b7a-ef15-4e14-a8c5-5f51552236a0&newPasswordHash=NewPassword");

            if (string.IsNullOrEmpty(req.ErrorMessage))
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show(req.ErrorMessage);
            }
        }

        #endregion Methods
    }
}
