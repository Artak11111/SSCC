using ControlCenter.Abstractions;
using ControlCenter.BL.Commands.Users.Model;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Users
{
    public class AuthenticateUserCommand
    {
        #region Fields

        private readonly IRepository<User> userRepository;

        #endregion Fields

        #region Constructor

        public AuthenticateUserCommand(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion Constructor

        #region Methods

        public async Task<AuthenticateUserResult> Execute(string email, string passwordHash)
        {
            // validations
            await ValidateInput(email, passwordHash);

            var user = await userRepository
                .Include(u=>u.Department)
                .FirstOrDefaultAsync(u => u.Email == email && (u.PasswordHash == null || u.PasswordHash == passwordHash));

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Department.Name),
                new Claim("UserId", user.Id.ToString()),
                new Claim("DepartmentId", user.Department.Id.ToString()),
            };

            return new AuthenticateUserResult
            {
                UserId =user.Id,
                Name = user.Name,
                Email = user.Email,
                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department.Name,
                UserIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType)
            };
        }

        private async Task ValidateInput(string email, string passwordHash)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            var user = await userRepository.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                throw new BusinessException($"User with email {email} not found");

            if (user.PasswordHash != null && user.PasswordHash != passwordHash)
               throw new BusinessException("Invalid email or password");
        }

        #endregion Methods
    }
}
