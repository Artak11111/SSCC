using ControlCenter.Client.Managers.Models;
using System.Collections.Generic;

namespace ControlCenter.Client.Models
{
    public class SettingsModel : BindableBase
    {
        #region Properties

        private List<Department> selectedDepartments = new List<Department>();

        public List<Department> SelectedDepartments
        {
            get => selectedDepartments;
            set => Set(ref selectedDepartments, value);
        }

        private List<Department> availableDepartments = new List<Department>();

        public List<Department> AvailableDepartments
        {
            get => availableDepartments;
            set => Set(ref availableDepartments, value);
        }

        #endregion Properties
    }
}
