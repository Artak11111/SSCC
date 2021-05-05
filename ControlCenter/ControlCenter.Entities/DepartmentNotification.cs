using System;

namespace ControlCenter.Entities
{
    public class DepartmentNotification : EntityBase
    {
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }


        public Guid NotificationId { get; set; }

        public Notification Notification { get; set; }
    }
}
