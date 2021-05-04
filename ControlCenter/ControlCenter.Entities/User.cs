using System;
using System.Collections.Generic;

namespace ControlCenter.Entities
{
    public class User : EntityBase
    {
        public DateTime Birthday { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        
        public Guid DepartmentId { get; set; }
        
        public Department Department { get; set; }
        
        public List<UserNotification> Notifications { get; set; }
    }
}