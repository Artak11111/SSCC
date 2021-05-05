using ControlCenter.Client.Managers;
using System.Windows.Input;
using ControlCenter.Client.Commands;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Regions;
using ControlCenter.Client.Views;

namespace ControlCenter.Client.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        #region Fields

        private readonly AccountManager accountManager;
        private readonly INavigationManager navgiationManager;

        #endregion Fields

        #region Constructor

        public SignUpViewModel(AccountManager accountManager, INavigationManager navgiationManager)
        {
            this.accountManager = accountManager;
            this.navgiationManager = navgiationManager;

            AddPropertyDependencies(nameof(CanSignUp), nameof(Email));
        }

        #endregion Constructor

        #region Properties

        private string email;
        public string Email
        {
            get => email;
            set => Set(ref email, value);
        }

        public bool CanSignUp => !string.IsNullOrEmpty(Email);

        #endregion Properties

        #region Commands

        public ICommand SignUpCommand => new Command(async () =>
        {
            IsBusy = true;
            var result = await accountManager.SignIn(Email, null);

            if(result)
                navgiationManager.RequestNavigate<Dashboard>(RegionNames.Main);
            else
                navgiationManager.RequestNavigate<SignIn>(RegionNames.Main);

            IsBusy = false;
        });

        #endregion Commands
    }
}