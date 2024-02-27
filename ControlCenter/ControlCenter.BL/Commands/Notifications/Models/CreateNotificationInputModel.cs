using ControlCenter.Entities.Models;

using System;
using System.Collections.Generic;

namespace ControlCenter.BL.Commands.Notifications.Models
{
    public class CreateNotificationInputModel
    {
        public string Message { get; set; }


        public RepeatInterval Repeat { get; set; }

        public DateTime DateTime { get; set; }

        public Guid? TargetUserId { get; set; }

        public bool IsForEveryOne { get; set; }

        public List<Guid> TargetDepartments { get; set; }
    }
}
