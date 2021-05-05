using ControlCenter.Client.Managers;
using System.Windows.Input;
using ControlCenter.Client.Commands;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Views;
using System.Threading.Tasks;

namespace ControlCenter.Client.ViewModels
{
    public class ChangePasswordViewModel : ViewModelBase
    {
        #region Fields

        private readonly AccountManager accountManager;
        private readonly UserSession.UserSession userSession;
        private readonly NavigationManager navgiationManager;

        #endregion Fields

        #region Constructor

        public ChangePasswordViewModel(UserSession.UserSession userSession, AccountManager accountManager, NavigationManager navgiationManager)
        {
            this.userSession = userSession;
            this.accountManager = accountManager;
            this.navgiationManager = navgiationManager;

            AddPropertyDependencies(nameof(CanChangePassword), nameof(Password));
        }

        #endregion Constructor

        #region Properties

        private string password;
        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }

        public string DepartmentName => userSession.DepartmentName;

        public string UserName => userSession.Name;
             
        public bool CanChangePassword => !string.IsNullOrEmpty(Password);

        #endregion Properties

        #region Commands

        public ICommand ChangePasswordCommand => new Command(async () =>
        {
            IsBusy = true;

            var result = await accountManager.ChangePassword(null, Password);

            if (result)
                navgiationManager.RequestNavigate<Dashboard>();

            IsBusy = false;
        });


        public ICommand CancelCommand => new Command(() =>
        {
            navgiationManager.NavigateBack();

            return Task.CompletedTask;
        });

        #endregion Commands
    }
}