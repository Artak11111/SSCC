using ControlCenter.Client.Managers;
using System.Windows.Input;
using ControlCenter.Client.Commands;
using ControlCenter.Client.Navigation;
using ControlCenter.Client.Views;
using ControlCenter.Client.Regions;
using ControlCenter.Client.Controls;
using ControlCenter.Client.Models;
using System.Linq;
using ControlCenter.Client.Helpers;
using System.Collections.Generic;
using ControlCenter.Client.Managers.Models;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace ControlCenter.Client.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        #region Fields

        private readonly AccountManager accountManager;
        private readonly NotificationManager notificationManager;
        private readonly DepartmentManager departmentManager;
        private readonly UserSession.UserSession userSession;
        private readonly NavigationManager navgiationManager;

        #endregion Fields

        #region Constructor

        public DashboardViewModel(UserSession.UserSession userSession, NotificationManager notificationManager, AccountManager accountManager, DepartmentManager departmentManager, NavigationManager navgiationManager)
        {
            this.userSession = userSession;
            this.notificationManager = notificationManager;
            this.departmentManager = departmentManager;
            this.accountManager = accountManager;
            this.navgiationManager = navgiationManager;

            AddPropertyDependencies(nameof(HasNewNotifications), nameof(NewNotificationsCount));
            AddPropertyDependencies(nameof(NewNotificationsCount), nameof(NewNotifications));

            Initialize();
        }

        #endregion Constructor

        #region Properties

        private bool isUserInfoPopupOpen;

        public bool IsUserInfoPopupOpen
        {
            get => isUserInfoPopupOpen;
            set => Set(ref isUserInfoPopupOpen, value);
        }

        private CreateEventModel createEventModel;

        public CreateEventModel CreateEventModel
        {
            get => createEventModel;
            set => Set(ref createEventModel, value);
        }

        private SettingsModel settingsModel;

        public SettingsModel SettingsModel
        {
            get => settingsModel;
            set => Set(ref settingsModel, value);
        }

        private ViewNotificationsModel viewNotificationsModel;

        public ViewNotificationsModel ViewNotificationsModel
        {
            get => viewNotificationsModel;
            set => Set(ref viewNotificationsModel, value);
        }

        public bool CanNavigateBack => navgiationManager.CanNavigateBack(RegionNames.Dashboard);

        public bool HasNewNotifications => NewNotifications?.Count > 0;

        public bool IsManager => userSession.DepartmentName == "Management";

        public string DepartmentName => userSession.DepartmentName;

        public string UserName => userSession.Name;

        public string Email => userSession.Email;

        public List<UserNotification> NewNotifications { get; set; } = new List<UserNotification>();

        public int NewNotificationsCount => NewNotifications?.Count ?? 0 ;

        public List<UserNotification> AllNotifications { get; set; } = new List<UserNotification>();

        public Timer Timer { get; set; }

        public Func<Task> OnNewNotificationRecieved { get; set; }

        public List<DisabledDepartment> DisabledDepartments { get; set; }

        #endregion Properties

        #region Commands

        public ICommand OpenUserInfoPopupCommand => new Command(() => IsUserInfoPopupOpen = true);

        public ICommand LogOutCommand => new Command(() =>
        {
            Timer.Stop();
            Timer.Dispose();

            accountManager.SignOut();
            navgiationManager.RemoveRegion(RegionNames.Dashboard);
            navgiationManager.RequestNavigate<SignIn>();
        });

        public ICommand NavigateToNotificationCreationCommand => new Command(async () =>
        {
            IsBusy = true;

            CreateEventModel = new CreateEventModel();

            CreateEventModel.AvailableDepartmens = await departmentManager.GetDepartments();
            CreateEventModel.AvailableUsers = await accountManager.GetUsers();

            IsBusy = false;

            if (CreateEventModel.AvailableDepartmens == null
                || CreateEventModel.AvailableUsers == null)
            {
                return;
            }

            navgiationManager.RequestNavigate<CreateNoificationControl>(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
        });

        public ICommand CreateEventCommand => new Command(async () =>
        {
            IsBusy = true;

            var result = await notificationManager.CreateNotification(new Managers.Models.CreateNotificationInputModel
            {
                DateTime = CreateEventModel.SelectedDate.ToUniversalTime(),
                IsForEveryOne = CreateEventModel.TargetType == EventTargetType.Everyone,
                Message = CreateEventModel.Message,
                Repeat = CreateEventModel.Repeat,
                TargetUserId = CreateEventModel.SelectedUser?.Id,
                TargetDepartments = CreateEventModel.SelectedDepartments?.Select(d=>d.Id).ToList()
            });

            IsBusy = false;

            if (!result)
                return;

            CreateEventModel = null;
            NavigateBackCommand.Execute(null);
        });


        public ICommand NavigateToNotificationsCommand => new Command(async () =>
        {
            IsBusy = true;

            if(NewNotifications.Any())
            {
                foreach (var notificaiton in NewNotifications)
                {
                    await notificationManager.MarkNotificationAsSeen(notificaiton.NotificationId);
                }

                NewNotifications.Clear();
            }

            ViewNotificationsModel = new ViewNotificationsModel();

            ViewNotificationsModel.Notifications = await notificationManager.GetNotifications();

            OnNewNotificationRecieved = async () =>
            {
                foreach (var notificaiton in NewNotifications)
                {
                    await notificationManager.MarkNotificationAsSeen(notificaiton.NotificationId);
                }

                var notifications = await notificationManager.GetNotifications();

                UIThreadHelper.AccessUIThread(()=> 
                {
                    ViewNotificationsModel.Notifications = notifications;

                    NewNotifications.Clear();
                    OnPropertyChanged(nameof(ViewNotificationsModel));
                    OnPropertyChanged(nameof(NewNotifications));
                });
            };

            IsBusy = false;

            navgiationManager.RequestNavigate<ViewNotificationsControl>(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
            OnPropertyChanged(nameof(NewNotifications));
        });


        public ICommand NavigateToOrganizationStructureCommand => new Command(() =>
        {
            navgiationManager.RequestNavigate<OrganizationStrucutreControl>(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
        });


        public ICommand NavigateToSettingsCommand => new Command(async () =>
        {
            IsBusy = true;

            SettingsModel = new SettingsModel();

            SettingsModel.AvailableDepartments = await departmentManager.GetDepartments();

            if(SettingsModel.AvailableDepartments == null)
            {
                IsBusy = false;
                return;
            }

            var disabledDepartments = await departmentManager.GetDisabledDepartments();

            if (disabledDepartments == null)
            {
                IsBusy = false;
                return;
            }

            foreach (var item in disabledDepartments)
            {
                var department = SettingsModel.AvailableDepartments.FirstOrDefault(d => d.Id == item.DepartmentId);

                if (department != null)
                    SettingsModel.SelectedDepartments.Add(department);
            }

            IsBusy = false;

            navgiationManager.RequestNavigate<NotificationSettingsControl>(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
        });

        public ICommand UpdateDisabledDepartmentsCommand => new Command(async () =>
        {
            IsBusy = true;

            var currentDepartments = await departmentManager.GetDisabledDepartments();

            foreach (var department in currentDepartments)
            {
                if (!SettingsModel.SelectedDepartments.Any(d => d.Id == department.DepartmentId))
                    await departmentManager.ChangeDepartmentStatus(department.DepartmentId);
            }

            foreach (var department in SettingsModel.SelectedDepartments)
            {
                if (!currentDepartments.Any(d => d.DepartmentId == department.Id))
                    await departmentManager.ChangeDepartmentStatus(department.Id);
            }

            DisabledDepartments = await departmentManager.GetDisabledDepartments();

            IsBusy = false;

            NavigateBackCommand.Execute(null);
            SettingsModel = null;
        });


        public ICommand NavigateBackCommand => new Command(() =>
        {
            OnNewNotificationRecieved = null;

            navgiationManager.NavigateBack(RegionNames.Dashboard);
            OnPropertyChanged(nameof(CanNavigateBack));
        });

        #endregion Commands

        #region Methods

        private async void Initialize()
        {
            Timer = new Timer(2000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();

            DisabledDepartments = await departmentManager.GetDisabledDepartments();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await OperationsHelper.RunAsync(async () => {
                try
                {
                    var hasNew = await notificationManager.CheckForNewNotifications();

                    if (hasNew == true)
                    {
                        var notifications = await notificationManager.GetNewNotifications();

                        if(DisabledDepartments.Any())
                        {
                            notifications = notifications.Where(n => DisabledDepartments.All(dn => dn.DepartmentId != n.Notification.DepartmentId)).ToList();
                        }

                        UIThreadHelper.AccessUIThread(() =>
                        {
                            NewNotifications = notifications;
                            OnPropertyChanged(nameof(NewNotificationsCount));

                            OnNewNotificationRecieved?.Invoke();
                        });
                    }
                }
                catch
                {
                }
            });
        }

        #endregion Methods
    }
}
