using ControlCenter.Client.Models;
using System;
using System.Collections.Generic;

namespace ControlCenter.Client.Managers.Models
{
    public class CreateNotificationInputModel
    {
        public string Message { get; set; }


        public RepeatInterval? Repeat { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public Guid? TargetUserId { get; set; }

        public bool IsForEveryOne { get; set; }

        public List<Guid> TargetDepartments { get; set; }
    }
}
