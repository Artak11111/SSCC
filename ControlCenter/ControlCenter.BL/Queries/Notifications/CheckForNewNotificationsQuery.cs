using ControlCenter.BL.Queries.Common;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Notifications
{
    public class CheckForNewNotificationsQuery : QueryBase<bool>
    {
        #region Constructor

        public CheckForNewNotificationsQuery(IUserInfoProvider userInfoProvider, IRepository<User> userRepository, IRepository<UserNotification> userNotificationRepository)
        {
            UserNotificationRepository = userNotificationRepository;
            UserRepository = userRepository;
            UserInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<User> UserRepository { get; }

        protected IRepository<UserNotification> UserNotificationRepository { get; }

        protected IUserInfoProvider UserInfoProvider { get; }

        #endregion Properties

        #region Methods

        public override Task<bool> ExecuteAsync()
        {
            return UserNotificationRepository
                .AnyAsync(un => un.UserId == UserInfoProvider.CurrentUserId && un.IsNew);
        }

        #endregion Methods
    }
}
