using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;
using ControlCenter.BL.Queries.Common;

namespace ControlCenter.BL.Queries.Notifications
{
    public class GetNewNotificationsQuery : QueryBase<List<UserNotification>>
    {
        #region Constructor

        public GetNewNotificationsQuery(IUserInfoProvider userInfoProvider, IRepository<User> userRepository, IRepository<UserNotification> userNotificationRepository)
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

        public override async Task<List<UserNotification>> ExecuteAsync()
        {
            var result = await UserNotificationRepository
                .Include(un => un.Notification.Department)
                .Where(un => un.UserId == UserInfoProvider.CurrentUserId && un.IsNew)
                .OrderByDescending(n => n.DateTime)
                .AsNoTracking()
                .ToListAsync();

            result.ForEach(n => n.Notification.TargetUsers = null);

            return result;
        }

        #endregion Methods
    }
}
