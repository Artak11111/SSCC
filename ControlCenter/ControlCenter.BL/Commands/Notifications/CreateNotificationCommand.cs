using ControlCenter.Abstractions;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Notifications
{
    public class CreateNotificationCommand
    {
        #region Fields

        private readonly IRepository<Department> departamentRepository;
        private readonly IRepository<Notification> notificationRepository;
        private readonly IRepository<DepartmentNotification> departmentNotificationRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public CreateNotificationCommand(IRepository<Department> departamentRepository, IRepository<Notification> notificationRepository, IRepository<User> userRepository, IUserInfoProvider userInfoProvider, IRepository<DepartmentNotification> departmentNotificationRepository)
        {
            this.notificationRepository = notificationRepository;
            this.userRepository = userRepository;
            this.departmentNotificationRepository = departmentNotificationRepository;
            this.departamentRepository = departamentRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute(CreateNotificationInputModel input)
        {
            // validations
            await ValidateInput(input);

            // creating notification
            var notification = new Notification
            {
                Id = new Guid(),
                Message = input.Message,
                NextScheduledNotificatinoDateTime = input.DateTime.ToUniversalTime(),
                IsForEveryOne = input.IsForEveryOne,
                TargetUserId = input.TargetUserId,
                DepartmentId = userInfoProvider.CurrentDepartmentId,
                Repeat = input.Repeat
            };

            notificationRepository.Add(notification);

            foreach (var departmentId in input.TargetDepartments)
            {
                departmentNotificationRepository.Add(new DepartmentNotification
                {
                    DepartmentId = departmentId,
                    NotificationId = notification.Id
                });
            }

            await notificationRepository.SaveChangesAsync();
        }

        private async Task ValidateInput(CreateNotificationInputModel input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            if (string.IsNullOrEmpty(input.Message)) throw new ArgumentNullException(nameof(input.Message));

            if ((input.IsForEveryOne && (input.TargetDepartments != null || input.TargetUserId != null))
                || !input.IsForEveryOne && input.TargetDepartments != null && input.TargetUserId != null)
                throw new InvalidOperationException("Notification target must be set once");

            if (input.Repeat == null && input.DateTime.ToUniversalTime() < DateTimeOffset.UtcNow)
                throw new InvalidOperationException("Invalid notification date");

            if (input.TargetUserId != null)
            {
                if (!await userRepository.AnyAsync(u => u.Id == input.TargetUserId))
                    throw new BusinessException("Target user not found");
            }
            else
            {
                foreach (var departamentId in input.TargetDepartments)
                {
                    if (!await departamentRepository.AnyAsync(d => d.Id == departamentId))
                        throw new BusinessException("One of target departments not found");
                }
            }
        }

        #endregion Methods
    }
}
