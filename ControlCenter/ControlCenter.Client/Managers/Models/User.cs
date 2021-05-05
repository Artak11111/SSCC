using System;

namespace ControlCenter.Client.Managers.Models
{
    public class User 
    {
        public Guid Id { get; set; }

        public DateTime Birthday { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public Guid DepartmentId { get; set; }
        
        public Department Department { get; set; }
    }
}