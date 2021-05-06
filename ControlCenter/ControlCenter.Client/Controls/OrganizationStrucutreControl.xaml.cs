using ControlCenter.Client.Managers.Models;
using ControlCenter.Client.ViewModels;
using System;
using System.Windows.Controls;

namespace ControlCenter.Client.Controls
{
    /// <summary>
    /// Interaction logic for OrganizationStrucutreControl.xaml
    /// </summary>
    public partial class OrganizationStrucutreControl : UserControl
    {
        public OrganizationStrucutreControl()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext as DashboardViewModel == null || (dataGrid.SelectedItem as User).DepartmentId == Guid.Empty) return;

            var user = dataGrid.SelectedItem as User;

            if (user.Department.Id == user.DepartmentId) return;

            (DataContext as DashboardViewModel).UpdateEmployeeDepartmentCommand.Execute(dataGrid.SelectedItem as User);
        }
    }
}
