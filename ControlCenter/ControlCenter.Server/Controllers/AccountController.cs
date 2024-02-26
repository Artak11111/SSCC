using ControlCenter.BL.Commands.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ControlCenter.BL.Queries.Users;
using ControlCenter.BL.Commands.Users.Models;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        #region Commands and Queries

        private readonly AuthenticateUserCommand AuthenticateUserCommand;
        private readonly ChangePasswordCommand ChangePasswordCommand;
        private readonly ChangeDepartmentCommand ChangeDepartmentCommand;
        private readonly GetUsersQuery GetUsersQuery;

        #endregion Commands and Queries

        #region Constructor

        public AccountController(GetUsersQuery getUsersQuery, 
            ChangeDepartmentCommand changeDepartmentCommand, 
            ChangePasswordCommand changePasswordCommand, 
            AuthenticateUserCommand authenticateUserCommand)
        {
            AuthenticateUserCommand = authenticateUserCommand;
            ChangePasswordCommand = changePasswordCommand;
            ChangeDepartmentCommand = changeDepartmentCommand;
            GetUsersQuery = getUsersQuery;
        }

        #endregion Constructor

        #region Actions

        [HttpPost]
        [Route("sign-in")]
        public Task<IActionResult> SignIn(string email, string passwordHash)
        {
            return Run(AuthenticateUserCommand, new AuthenticateUserInputModel
            {
                Email = email,
                Password = passwordHash
            });
        }

        [HttpPost]
        [Route("change-password")]
        [Authorize]
        public Task<IActionResult> ChangePassword(string oldPasswordHash, string newPasswordHash)
        {
            return Run(ChangePasswordCommand, new ChangePasswordInputModel 
            { 
                NewPassword = newPasswordHash,
                OldPassword = oldPasswordHash
            });
        }

        [HttpPost]
        [Route("change-department")]
        [Authorize(Roles = "Management")]
        public Task<IActionResult> ChangeDepartment(Guid userId, Guid departmentId)
        {
            return Run(ChangeDepartmentCommand, new ChangeDepartmentInputModel
            {
                NewDepartmentId = userId,
                OldDepartmentId = departmentId
            });
        }


        [HttpGet]
        [Route("get-users")]
        public Task<IActionResult> GetUsers()
        {
            return Run(GetUsersQuery);
        }

        #endregion Actions
    }
}
