using ControlCenter.BL.Commands.Common;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Exceptions;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Notifications
{
    public class CreateNotificationCommand : CommandBase<CreateNotificationInputModel>
    {
        #region Constructor

        public CreateNotificationCommand(IRepository<Department> departmentRepository, 
            IRepository<Notification> notificationRepository, 
            IRepository<User> userRepository, 
            IRepository<DepartmentNotification> departmentNotificationRepository,
            IUserInfoProvider userInfoProvider)
        {
            this.NotificationRepository = notificationRepository;
            this.UserRepository = userRepository;
            this.DepartmentNotificationRepository = departmentNotificationRepository;
            this.DepartmentRepository = departmentRepository;
            this.UserInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<Notification> NotificationRepository { get; }

        protected IRepository<User> UserRepository { get; }

        protected IRepository<DepartmentNotification> DepartmentNotificationRepository { get; }

        protected IRepository<Department> DepartmentRepository { get; }

        protected IUserInfoProvider UserInfoProvider { get; }

        #endregion Properties

        #region Methods

        public override async Task ExecuteAsync(CreateNotificationInputModel input)
        {
            await ValidateAsync(input);

            var notification = new Notification
            {
                Id = new Guid(),
                Message = input.Message,
                NextScheduledNotificatinoDateTime = input.DateTime.ToUniversalTime(),
                IsForEveryOne = input.IsForEveryOne,
                TargetUserId = input.TargetUserId,
                DepartmentId = UserInfoProvider.CurrentDepartmentId,
                Repeat = input.Repeat
            };

            NotificationRepository.Add(notification);

            await NotificationRepository.SaveChangesAsync();

            foreach (var departmentId in input.TargetDepartments ?? new System.Collections.Generic.List<Guid>())
            {
                DepartmentNotificationRepository.Add(new DepartmentNotification
                {
                    DepartmentId = departmentId,
                    NotificationId = notification.Id
                });
            }

            await DepartmentNotificationRepository.SaveChangesAsync();
        }

        protected override async Task ValidateAsync(CreateNotificationInputModel input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            if (string.IsNullOrEmpty(input.Message)) throw new ArgumentNullException(nameof(input.Message));

            if ((input.IsForEveryOne && (input.TargetDepartments != null || input.TargetUserId != null))
                || !input.IsForEveryOne && input.TargetDepartments != null && input.TargetUserId != null)
                throw new InvalidOperationException("Notification target must be set once");

            if (input.Repeat == RepeatInterval.Never && input.DateTime.ToUniversalTime() < DateTime.UtcNow.AddMinutes(-10))
                throw new InvalidOperationException("Invalid notification date");

            if (input.TargetUserId != null)
            {
                if (!await UserRepository.AnyAsync(u => u.Id == input.TargetUserId))
                    throw new BusinessException("Target user not found");

                return;
            }

            foreach (var departamentId in input.TargetDepartments ?? new System.Collections.Generic.List<Guid>())
            {
                if (!await DepartmentRepository.AnyAsync(d => d.Id == departamentId))
                    throw new BusinessException($"One of target departments not found. Department Id: {departamentId}");
            }
        }

        #endregion Methods
    }
}
