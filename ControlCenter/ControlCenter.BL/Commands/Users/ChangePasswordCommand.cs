using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Users
{
    public class ChangePasswordCommand
    {
        #region Fields

        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public ChangePasswordCommand(IRepository<User> userRepository, IUserInfoProvider userInfoProvider)
        {
            this.userRepository = userRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute(string oldPasswordHash, string newPasswordHash)
        {
            // validations
            await ValidateInput(oldPasswordHash, newPasswordHash);

            var user = await userRepository
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == userInfoProvider.CurrentUserId && (u.PasswordHash == null || u.PasswordHash == oldPasswordHash));

            user.PasswordHash = newPasswordHash;

            await userRepository.SaveChangesAsync();
        }

        private async Task ValidateInput(string oldPasswordHash, string newPasswordHash)
        {
            if (string.IsNullOrEmpty(newPasswordHash)) throw new ArgumentNullException(nameof(newPasswordHash));

            if (!await userRepository.AnyAsync(u => u.Id == userInfoProvider.CurrentUserId && (u.PasswordHash == null || u.PasswordHash == oldPasswordHash)))
            {
                if (string.IsNullOrEmpty(oldPasswordHash))
                    throw new BusinessException($"User with not found");
                else
                    throw new BusinessException("Invalid id or password");
            }
        }

        #endregion Methods
    }
}
