using ControlCenter.BL.Commands.Users;
using ControlCenter.BL.Exceptions;
using ControlCenter.Server.TaskExecutor;
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
        private readonly TaskExecutor.TaskExecutor taskExecutor;

        #endregion Commands and Queries

        #region Constructor

        public AccountController(ChangePasswordCommand changePasswordCommand, AuthenticateUserCommand authenticateUserCommand, TaskExecutor.TaskExecutor taskExecutor)
        {
            this.authenticateUserCommand = authenticateUserCommand;
            this.changePasswordCommand = changePasswordCommand;
            this.taskExecutor = taskExecutor;
        }

        #endregion Constructor

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(string email, string passwordHash)
        {
            var result = await taskExecutor.Execute(async ()=> 
            {
                var claimsIdentity = await authenticateUserCommand.Execute(email, passwordHash);

                var now = DateTime.UtcNow;
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        notBefore: now,
                        claims: claimsIdentity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return encodedJwt;
            });

            if(result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost()]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(Guid userId, string oldPasswordHash, string newPasswordHash)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                await changePasswordCommand.Execute(userId, oldPasswordHash, newPasswordHash);
            });

            if (result.ErrorMessage == null)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
