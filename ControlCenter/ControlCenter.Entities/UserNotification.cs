using System;

namespace ControlCenter.Entities
{
    public class UserNotification : EntityBase
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid NotificationId { get; set; }

        public Notification Notification { get; set; }

        public bool IsNew { get; set; } = true;
        
        public string Message { get; set; }

        public DateTimeOffset DateTime { get; set; }
    }
}
