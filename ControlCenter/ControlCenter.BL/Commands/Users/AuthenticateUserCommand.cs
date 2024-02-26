using ControlCenter.BL.Authentication;
using ControlCenter.BL.Commands.Common;
using ControlCenter.BL.Commands.Users.Model;
using ControlCenter.BL.Commands.Users.Models;
using ControlCenter.BL.Exceptions;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Users
{
    public class AuthenticateUserCommand : CommandBase<AuthenticateUserInputModel, AuthenticateUserResult>
    {
        #region Constructor

        public AuthenticateUserCommand(IRepository<User> userRepository)
        {
            this.UserRepository = userRepository;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<User> UserRepository { get; }

        #endregion Properties

        #region Methods

        public override async Task<AuthenticateUserResult> ExecuteAsync(AuthenticateUserInputModel input)
        {
            await ValidateAsync(input);

            var user = await UserRepository
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Email == input.Email && (u.PasswordHash == null || u.PasswordHash == input.Password));

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Department.Name),
                new Claim("UserId", user.Id.ToString()),
                new Claim("DepartmentId", user.Department.Id.ToString()),
            };

            var userIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: userIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthenticateUserResult
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department.Name,
                Token = encodedJwt
            };
        }

        protected override async Task ValidateAsync(AuthenticateUserInputModel input)
        {
            if (string.IsNullOrEmpty(input.Email)) throw new ArgumentNullException(nameof(input.Email));

            var user = await UserRepository.FirstOrDefaultAsync(u => u.Email == input.Email);

            if (user == null)
                throw new BusinessException($"User with email {input.Email} not found");

            if (user.PasswordHash != null && user.PasswordHash != input.Password)
                throw new BusinessException("Invalid email or password");
        }

        #endregion Methods
    }
}
