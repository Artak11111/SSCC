using ControlCenter.Client.Managers.Models;
using System.Collections.Generic;

namespace ControlCenter.Client.Models
{
    public class OrganizationStructureModel
    {
        #region Properties

        public List<User> Employees { get; set; }

        public List<Department> Departments { get; set; }

        #endregion Properties
    }
}
