using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Notifications
{
    public class GetNewNotificationsQuery
    {
        #region Fields

        private readonly IRepository<UserNotification> userNotificationRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public GetNewNotificationsQuery(IUserInfoProvider userInfoProvider, IRepository<User> userRepository, IRepository<UserNotification> userNotificationRepository)
        {
            this.userNotificationRepository = userNotificationRepository;
            this.userRepository = userRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<UserNotification>> Execute()
        {
            // validations
            await ValidateInput();

            var result = await userNotificationRepository
                .Include(un => un.Notification.Department)
                .Where(un => un.UserId == userInfoProvider.CurrentUserId && un.IsNew)
                .OrderByDescending(n => n.DateTime)
                .AsNoTracking()
                .ToListAsync();

            result.ForEach(n => n.Notification.TargetUsers = null);

            return result;
        }

        private async Task ValidateInput()
        {
            if (!await userRepository.AnyAsync(u => u.Id == userInfoProvider.CurrentUserId))
                throw new BusinessException("User not found");
        }

        #endregion Methods
    }
}
