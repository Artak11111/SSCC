using System;

namespace ControlCenter.Entities.Models
{
    public class DisabledDepartment : EntityBase
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
