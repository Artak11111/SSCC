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

        public async Task<List<Notification>> Execute()
        {
            // validations
            await ValidateInput();

            return await userNotificationRepository
                .Include(un => un.Notification.Department)
                .Where(un => un.UserId == userInfoProvider.CurrentUserId && un.IsNew)
                .Select(un => un.Notification)
                .OrderByDescending(n => n.DateTime)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task ValidateInput()
        {
            if (!await userRepository.AnyAsync(u => u.Id == userInfoProvider.CurrentUserId))
                throw new BusinessException("User not found");
        }

        #endregion Methods
    }
}
