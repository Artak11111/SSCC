using System;

namespace ControlCenter.Client.Managers.Models
{
    public class DisabledDepartment
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
