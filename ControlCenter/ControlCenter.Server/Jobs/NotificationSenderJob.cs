using ControlCenter.Abstractions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControlCenter.Server.Jobs
{
    public class NotificationSenderJob
    {
        #region Fields

        public const string Key = "NotificationSenderJob_Key";

        private readonly IRepository<Notification> notificationRepository;
        private readonly IRepository<UserNotification> userNotificationRepository;
        private readonly IRepository<User> userRepository;
        private readonly Semaphore semaphore = new Semaphore(1,1, "Syncronization_Object");

        #endregion Fields

        #region Constructor

        public NotificationSenderJob(IRepository<Notification> notificationRepository, IRepository<UserNotification> userNotificationRepository, IRepository<User> userRepository)
        {
            this.notificationRepository = notificationRepository;
            this.userNotificationRepository = userNotificationRepository;
            this.userRepository = userRepository;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute()
        {
            semaphore.WaitOne();

            try
            {
                var notifications = await notificationRepository
                .Include(n => n.TargetDepartments)
                .Where(n => n.NextScheduledNotificatinoDateTime <= DateTimeOffset.UtcNow)
                .ToListAsync();

                foreach (var notification in notifications)
                {
                    // depending on target, create relations
                    if (notification.TargetUserId != null)
                    {
                        userNotificationRepository.Add(new UserNotification
                        {
                            Message = notification.Message,
                            UserId = notification.TargetUserId.Value,
                            NotificationId = notification.Id,
                            IsNew = true,
                            DateTime = notification.NextScheduledNotificatinoDateTime.Value
                        });

                        notification.NextScheduledNotificatinoDateTime = GetNextNotificationTime(notification);

                        continue;
                    }

                    var targetUsers = notification.IsForEveryOne
                        ? await userRepository.AsQueryable().AsNoTracking().ToListAsync()
                        : (await userRepository.AsQueryable().AsNoTracking().ToListAsync())
                            .Where(u => notification.TargetDepartments.Any(d => d.DepartmentId == u.DepartmentId)).ToList();

                    foreach (var user in targetUsers)
                    {
                        userNotificationRepository.Add(new UserNotification
                        {
                            Message = notification.Message,
                            UserId = user.Id,
                            NotificationId = notification.Id,
                            IsNew = true,
                            DateTime = notification.NextScheduledNotificatinoDateTime.Value
                        });
                    }

                    notification.NextScheduledNotificatinoDateTime = GetNextNotificationTime(notification);

                    await userNotificationRepository.SaveChangesAsync();
                    await notificationRepository.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }

            semaphore.Release();
        }

        private DateTimeOffset? GetNextNotificationTime(Notification notification)
        {
            return notification.Repeat switch
            {
                RepeatInterval.Never => null,
                RepeatInterval.TwiceADay => notification.NextScheduledNotificatinoDateTime.Value.AddHours(12),
                RepeatInterval.Daily => notification.NextScheduledNotificatinoDateTime.Value.AddDays(1),
                RepeatInterval.Weekly => notification.NextScheduledNotificatinoDateTime.Value.AddDays(7),
                RepeatInterval.Monthly => notification.NextScheduledNotificatinoDateTime.Value.AddMonths(1),
                RepeatInterval.Yearly => notification.NextScheduledNotificatinoDateTime.Value.AddYears(1),
                _ => throw new NotImplementedException()
            };
        }

        #endregion Methods
    }
}
