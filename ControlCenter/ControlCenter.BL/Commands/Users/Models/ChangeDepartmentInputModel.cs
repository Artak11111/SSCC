using System;

namespace ControlCenter.BL.Commands.Users.Models
{
    public class ChangeDepartmentInputModel
    {
        public Guid OldDepartmentId { get; set; }

        public Guid NewDepartmentId { get; set; }
    }
}
