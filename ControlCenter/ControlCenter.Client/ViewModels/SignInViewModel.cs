using ControlCenter.Client.Managers;
using System.Windows.Input;
using ControlCenter.Client.Commands;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Regions;
using ControlCenter.Client.Views;
using System.Threading.Tasks;

namespace ControlCenter.Client.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        #region Fields

        private readonly AccountManager accountManager;
        private readonly NavigationManager navgiationManager;

        #endregion Fields

        #region Constructor

        public SignInViewModel(AccountManager accountManager, NavigationManager navgiationManager)
        {
            this.accountManager = accountManager;
            this.navgiationManager = navgiationManager;

            AddPropertyDependencies(nameof(CanSignIn), nameof(Email), nameof(Password));
        }

        #endregion Constructor

        #region Properties

        private string email;
        public string Email
        {
            get => email;
            set => Set(ref email, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }

        public bool CanSignIn => !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email);

        #endregion Properties

        #region Commands

        public ICommand SignInCommand => new Command(async () =>
        {
            IsBusy = true;

            var result = await accountManager.SignIn(Email, Password);

            IsBusy = false;

            if (!result) return;

            navgiationManager.RequestNavigate<Dashboard>(RegionNames.Main);
        });

        public ICommand SignUpCommand => new Command(() =>
        {
            navgiationManager.RequestNavigate<SignUp>(RegionNames.Main);

            return Task.CompletedTask;
        });

        #endregion Commands
    }
}