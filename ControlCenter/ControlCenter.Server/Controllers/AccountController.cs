using ControlCenter.BL.Commands.Users;
using ControlCenter.Server.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        #region Commands and Queries

        private readonly AuthenticateUserCommand authenticateUserCommand;
        private readonly ChangePasswordCommand changePasswordCommand;
        private readonly ChangeDepartmentCommand changeDepartmentCommand;
        private readonly TaskExecutor.TaskExecutor taskExecutor;

        #endregion Commands and Queries

        #region Constructor

        public AccountController(ChangeDepartmentCommand changeDepartmentCommand, ChangePasswordCommand changePasswordCommand, AuthenticateUserCommand authenticateUserCommand, TaskExecutor.TaskExecutor taskExecutor)
        {
            this.authenticateUserCommand = authenticateUserCommand;
            this.changePasswordCommand = changePasswordCommand;
            this.changeDepartmentCommand = changeDepartmentCommand;
            this.taskExecutor = taskExecutor;
        }

        #endregion Constructor

        #region Actions

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(string email, string passwordHash)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                var authenticationResult = await authenticateUserCommand.Execute(email, passwordHash);

                var now = DateTime.UtcNow;
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: authenticationResult.UserIdentity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new Models.SignInResult
                {
                    UserId = authenticationResult.UserId,
                    Name = authenticationResult.Name,
                    DepartmentId = authenticationResult.DepartmentId,
                    DepartmentName = authenticationResult.DepartmentName,
                    Email = authenticationResult.Email,
                    Token = encodedJwt
                };
            });

            if (result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPasswordHash, string newPasswordHash)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                await changePasswordCommand.Execute(oldPasswordHash, newPasswordHash);
            });

            if (result.ErrorMessage == null)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Route("ChangeDepartment")]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> ChangeDepartment(Guid userId, Guid departmentId)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                await changeDepartmentCommand.Execute(userId, departmentId);
            });

            if (result.ErrorMessage == null)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessage);
        }

        #endregion Actions
    }
}
