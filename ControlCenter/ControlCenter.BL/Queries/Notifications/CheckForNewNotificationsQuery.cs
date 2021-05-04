using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Notifications
{
    public class CheckForNewNotificationsQuery
    {
        #region Fields

        private readonly IRepository<UserNotification> userNotificationRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public CheckForNewNotificationsQuery(IUserInfoProvider userInfoProvider, IRepository<User> userRepository, IRepository<UserNotification> userNotificationRepository)
        {
            this.userNotificationRepository = userNotificationRepository;
            this.userRepository = userRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task<bool> Execute()
        {
            // validations
            await ValidateInput();

            return await userNotificationRepository
                .AnyAsync(un => un.UserId == userInfoProvider.CurrentUserId && un.IsNew);
        }

        private async Task ValidateInput()
        {
            if (!await userRepository.AnyAsync(u => u.Id == userInfoProvider.CurrentUserId))
                throw new BusinessException("User not found");
        }

        #endregion Methods
    }
}
