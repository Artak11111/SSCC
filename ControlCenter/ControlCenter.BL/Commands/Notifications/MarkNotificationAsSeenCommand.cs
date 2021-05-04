using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Notifications
{
    public class MarkNotificationAsSeenCommand
    {
        #region Fields

        private readonly IRepository<UserNotification> userNotificationRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public MarkNotificationAsSeenCommand(IUserInfoProvider userInfoProvider, IRepository<UserNotification> userNotificationRepository)
        {
            this.userNotificationRepository = userNotificationRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute(Guid notificationId)
        {
            // validations
            await ValidateInput(notificationId);

            var userNotification = await userNotificationRepository
                .FirstOrDefaultAsync(un => un.NotificationId == notificationId && un.UserId == userInfoProvider.CurrentUserId);

            userNotification.IsNew = false;

            await userNotificationRepository.SaveChangesAsync();
        }

        private async Task ValidateInput(Guid notificationId)
        {
            if (notificationId == default) throw new ArgumentNullException(nameof(notificationId));

            if (!await userNotificationRepository.AnyAsync(un=> un.NotificationId == notificationId && un.UserId == userInfoProvider.CurrentUserId))
                throw new BusinessException("Notification not found");
        }

        #endregion Methods
    }
}
