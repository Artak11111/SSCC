using ControlCenter.Client.Managers.Models;
using ControlCenter.Client.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ControlCenter.Client.Controls
{
    /// <summary>
    /// Interaction logic for NotificationSettingsControl.xaml
    /// </summary>
    public partial class NotificationSettingsControl : UserControl
    {
        public NotificationSettingsControl()
        {
            InitializeComponent();

            Loaded += NotificationSettingsControl_Loaded;
        }

        private void NotificationSettingsControl_Loaded(object sender, RoutedEventArgs e)
        {
            var departments = (DataContext as DashboardViewModel).SettingsModel.SelectedDepartments;

            if(departments?.Any() == true)
            {
                foreach (var department in departments)
                {
                    listView.SelectedItems.Add(department);
                }
            }

            listView.SelectionChanged += SelectionChanged;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DataContext as DashboardViewModel)?.SettingsModel == null) return;

            (DataContext as DashboardViewModel).SettingsModel.SelectedDepartments = listView.SelectedItems.Cast<Department>().ToList();
        }
    }
}
