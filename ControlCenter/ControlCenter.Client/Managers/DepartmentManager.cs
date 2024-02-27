using ControlCenter.Client.Client;
using ControlCenter.Client.Managers.Models;
using ControlCenter.Client.Services;
using System;
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

        private readonly string GetDepartmentsUrl = $"{ControllerName}/get-departments";
        private readonly string GetDisabledDepartmentsUrl = $"{ControllerName}/get-disabled-departments";
        private readonly string ChangeDepartmentStatusUrl = $"{ControllerName}/change-department-status";

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
            var response = await client.SendAsync<List<Department>>(HttpMethod.Get, GetDepartmentsUrl);

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return null;
            }

            return response.Result;
        }

        public async Task<List<DisabledDepartment>> GetDisabledDepartments()
        {
            var response = await client.SendAsync<List<DisabledDepartment>>(HttpMethod.Get, GetDisabledDepartmentsUrl);

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                notificationService.ShowError(response.ErrorMessage);
                return null;
            }

            return response.Result;
        }

        public async Task<bool> ChangeDepartmentStatus(Guid departmentId)
        {
            var response = await client.SendAsync(HttpMethod.Post, $"{ChangeDepartmentStatusUrl}?departmentId={departmentId}");

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
