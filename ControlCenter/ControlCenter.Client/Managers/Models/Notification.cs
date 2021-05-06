using ControlCenter.Client.Models;
using System;

namespace ControlCenter.Client.Managers.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public RepeatInterval Repeat { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
