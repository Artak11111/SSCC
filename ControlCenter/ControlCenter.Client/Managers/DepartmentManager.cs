using ControlCenter.Client.Client;
using ControlCenter.Client.Managers.Models;
using ControlCenter.Client.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ControlCenter.Client.Managers
{
    public class DepartmentManager
    {
        #region Fields

        private readonly ApiClient client;
        private readonly NotificationService notificationService;

        //endpoints

        private const string ControllerName = "Departments";

        private readonly string GetDepartmentsUrl = $"{ControllerName}/GetDepartments";

        #endregion Fields

        #region Constructor

        public DepartmentManager(ApiClient client, NotificationService notificationService)
        {
            this.client = client;
            this.notificationService = notificationService;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<Department>> GetDepartments()
        {
            var response = await client.SendAsync<List<Department>>(HttpMethod.Post, GetDepartmentsUrl);

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
