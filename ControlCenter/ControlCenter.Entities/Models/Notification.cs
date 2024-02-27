using System;
using System.Collections.Generic;

namespace ControlCenter.Entities.Models
{
    public class Notification : EntityBase
    {
        public string Message { get; set; }

        public RepeatInterval Repeat { get; set; }

        public DateTimeOffset? NextScheduledNotificatinoDateTime { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }



        public List<DepartmentNotification> TargetDepartments { get; set; }

        public Guid? TargetUserId { get; set; }

        public bool IsForEveryOne { get; set; }



        public List<UserNotification> TargetUsers { get; set; }
    }
}
