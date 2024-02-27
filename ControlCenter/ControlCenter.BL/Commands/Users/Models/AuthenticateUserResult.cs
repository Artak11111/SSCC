using System;

namespace ControlCenter.BL.Commands.Users.Model
{
    public class AuthenticateUserResult
    {
        public string Token { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
