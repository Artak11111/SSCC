using ControlCenter.Abstractions;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Notifications
{
    public class CreateNotificationCommand
    {
        #region Fields

        private readonly IRepository<Department> departamentRepository;
        private readonly IRepository<Notification> notificationRepository;
        private readonly IRepository<UserNotification> userNotificationRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public CreateNotificationCommand(IRepository<Department> departamentRepository, IRepository<Notification> notificationRepository, IRepository<User> userRepository, IUserInfoProvider userInfoProvider, IRepository<UserNotification> userNotificationRepository)
        {
            this.notificationRepository = notificationRepository;
            this.userRepository = userRepository;
            this.userNotificationRepository = userNotificationRepository;
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
                DateTime = input.DateTime.ToUniversalTime(),
                IsForEveryOne = input.IsForEveryOne,
                DepartmentId = userInfoProvider.CurrentDepartmentId,
                Repeat = input.Repeat
            };

            // depending on target, create relations
            if (input.TargetUserId != null)
            {
                userNotificationRepository.Add(new UserNotification
                {
                    Id = new Guid(),
                    UserId = input.TargetUserId.Value,
                    NotificationId = notification.Id
                });
            }
            else
            {
                var targetUsers = await userRepository.Where(u => input.TargetDepartments.Contains(u.DepartmentId)).ToListAsync();
                userNotificationRepository.Add(new UserNotification
                {
                    Id = new Guid(),
                    UserId = input.TargetUserId.Value,
                    NotificationId = notification.Id
                });
            }

            notificationRepository.Add(notification);

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
