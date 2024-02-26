using ControlCenter.BL.Commands.Common;
using ControlCenter.BL.Exceptions;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Notifications
{
    public class MarkNotificationAsSeenCommand : CommandBase<Guid>
    {
        #region Constructor

        public MarkNotificationAsSeenCommand(IUserInfoProvider userInfoProvider, 
            IRepository<UserNotification> userNotificationRepository)
        {
            UserNotificationRepository = userNotificationRepository;
            UserInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<UserNotification> UserNotificationRepository { get; }

        protected IUserInfoProvider UserInfoProvider { get; }

        #endregion Properties

        #region Methods

        public override async Task ExecuteAsync(Guid notificationId)
        {
            await ValidateAsync(notificationId);

            var userNotification = await UserNotificationRepository
                .FirstOrDefaultAsync(un => un.NotificationId == notificationId && un.UserId == UserInfoProvider.CurrentUserId);

            userNotification.IsNew = false;

            await UserNotificationRepository.SaveChangesAsync();
        }

        protected override async Task ValidateAsync(Guid notificationId)
        {
            if (notificationId == default) throw new ArgumentNullException(nameof(notificationId));

            if (!await UserNotificationRepository.AnyAsync(un=> un.NotificationId == notificationId && un.UserId == UserInfoProvider.CurrentUserId))
                throw new BusinessException("Notification not found");
        }

        #endregion Methods
    }
}
