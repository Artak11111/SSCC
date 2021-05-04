using ControlCenter.Client.ViewModels;
using System.Windows.Controls;

namespace ControlCenter.Client.Views
{
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();

            Initialized += SignIn_Initialized;
        }

        private void SignIn_Initialized(object sender, System.EventArgs e)
        {
            DataContext = new SignInViewModel();
        }
    }
}