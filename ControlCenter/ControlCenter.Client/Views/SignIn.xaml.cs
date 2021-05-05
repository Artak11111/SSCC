using ControlCenter.Client.ViewModels;
using System.Windows.Controls;

namespace ControlCenter.Client.Views
{
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as SignInViewModel).Password = (sender as PasswordBox).Password;
        }
    }
}