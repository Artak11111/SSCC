using System;

namespace ControlCenter.Entities
{
    public class DisabledDepartment : EntityBase
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
