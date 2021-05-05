using ControlCenter.Client.Managers;
using System.Windows.Input;
using ControlCenter.Client.Commands;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Views;
using ControlCenter.Client.Regions;
using ControlCenter.Client.Controls;

namespace ControlCenter.Client.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        #region Fields

        private readonly AccountManager accountManager;
        private readonly UserSession.UserSession userSession;
        private readonly NavigationManager navgiationManager;

        #endregion Fields

        #region Constructor

        public DashboardViewModel(UserSession.UserSession userSession, AccountManager accountManager, NavigationManager navgiationManager)
        {
            this.userSession = userSession;
            this.accountManager = accountManager;
            this.navgiationManager = navgiationManager;

            AddPropertyDependencies(nameof(HasNewNotifications), nameof(NewNotificationsCount));
        }

        #endregion Constructor

        #region Properties

        private bool isUserInfoPopupOpen;

        public bool IsUserInfoPopupOpen
        {
            get => isUserInfoPopupOpen;
            set => Set(ref isUserInfoPopupOpen, value);
        }

        private int newNotificationsCount;

        public int NewNotificationsCount
        {
            get => newNotificationsCount;
            set => Set(ref newNotificationsCount, value);
        }

        public bool CanNavigateBack => navgiationManager.CanNavigateBack(RegionNames.Dashboard);

        public bool HasNewNotifications => NewNotificationsCount > 0;

        public bool IsManager => userSession.DepartmentName == "Management";

        public string DepartmentName => userSession.DepartmentName;

        public string UserName => userSession.Name;

        public string Email => userSession.Email;

        #endregion Properties

        #region Commands

        public ICommand OpenUserInfoPopupCommand => new Command(() => IsUserInfoPopupOpen = true);
        
        public ICommand LogOutCommand => new Command(() =>
        {
            accountManager.SignOut();
            navgiationManager.RequestNavigate<SignIn>();
        });

        public ICommand NavigateToNotificationCreationCommand => new Command(() =>
        {
            navgiationManager.RequestNavigate<CreateNoificationControl>(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
        });

        public ICommand NavigateBackCommand => new Command(() =>
        {
            navgiationManager.NavigateBack(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
        });

        #endregion Commands
    }
}
