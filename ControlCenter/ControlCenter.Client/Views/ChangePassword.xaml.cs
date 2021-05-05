using ControlCenter.Client.ViewModels;
using System.Windows.Controls;

namespace ControlCenter.Client.Views
{
    public partial class ChangePassword : UserControl
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as ChangePasswordViewModel).Password = (sender as PasswordBox).Password;
        }
    }
}