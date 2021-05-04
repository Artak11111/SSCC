using System;
using System.Collections.Generic;

namespace ControlCenter.Entities
{
    public class Notification : EntityBase
    {
        public string Message { get; set; }


        public RepeatInterval? Repeat { get; set; }

        public DateTimeOffset DateTime { get; set; }

        
        public Guid DepartmentId { get; set; }
        
        public Department Department { get; set; }

        public bool IsForEveryOne { get; set; }

        public List<UserNotification> TargetUsers { get; set; }
    }
}