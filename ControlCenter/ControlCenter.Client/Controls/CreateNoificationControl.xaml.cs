using ControlCenter.Client.Managers.Models;
using ControlCenter.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlCenter.Client.Controls
{
    public partial class CreateNoificationControl : UserControl
    {
        public CreateNoificationControl()
        {
            InitializeComponent();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DataContext as DashboardViewModel)?.CreateEventModel == null) return;

            (DataContext as DashboardViewModel).CreateEventModel.SelectedDepartments = departments.SelectedItems.Cast<Department>().ToList();
        }
    }
}
