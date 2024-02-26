using ControlCenter.Client.Managers.Models;
using System;
using System.Collections.Generic;

namespace ControlCenter.Client.Models
{
    public class CreateEventModel : BindableBase
    {
        #region Constructor

        public CreateEventModel()
        {
            AddPropertyDependencies(nameof(CanCreateEvent), nameof(SelectedDate), nameof(Message));
            AddPropertyDependencies(nameof(IsTargetLabelVisible), nameof(TargetType));
            AddPropertyDependencies(nameof(IsUserComboboxVisible), nameof(TargetType));
            AddPropertyDependencies(nameof(IsDepartmentListViewVisible), nameof(TargetType));
        }

        #endregion Constructor

        #region Properties

        private EventTargetType targetType = EventTargetType.Everyone;

        public EventTargetType TargetType
        {
            get => targetType;
            set => Set(ref targetType, value);
        }

        public EventTargetType[] AvailableTargetTypes => Enum.GetValues<EventTargetType>();

        public bool IsTargetLabelVisible => TargetType != EventTargetType.Everyone;

        public bool IsUserComboboxVisible => TargetType == EventTargetType.User;

        public bool IsDepartmentListViewVisible => TargetType == EventTargetType.Department;

        private User selectedUser;

        public User SelectedUser
        {
            get => selectedUser;
            set => Set(ref selectedUser, value);
        }

        private List<User> availableUsers;

        public List<User> AvailableUsers
        {
            get => availableUsers;
            set => Set(ref availableUsers, value);
        }


        private List<Department> selectedDepartments;

        public List<Department> SelectedDepartments
        {
            get => selectedDepartments;
            set => Set(ref selectedDepartments, value);
        }

        private List<Department> availableDepartmens;

        public List<Department> AvailableDepartmens
        {
            get => availableDepartmens;
            set => Set(ref availableDepartmens, value);
        }

        private RepeatInterval repeat = RepeatInterval.Never;

        public  RepeatInterval Repeat
        {
            get => repeat;
            set => Set(ref repeat, value);
        }

        public RepeatInterval[] AvailableRepeatTypes => Enum.GetValues<RepeatInterval>();

        private DateTime selectedDate = DateTime.UtcNow;

        public DateTime SelectedDate
        {
            get => selectedDate;
            set => Set(ref selectedDate, value);
        }

        private string message;

        public string Message
        {
            get => message;
            set => Set(ref message, value);
        }

        public bool CanCreateEvent => SelectedDate >= DateTime.UtcNow
            && !string.IsNullOrWhiteSpace(Message);


        #endregion Properties
    }

    public enum EventTargetType
    {
        Everyone,
        User,
        Department
    }
}
