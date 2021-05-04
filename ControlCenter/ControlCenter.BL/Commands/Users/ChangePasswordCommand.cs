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

        #endregion Fields

        #region Constructor

        public ChangePasswordCommand(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute(Guid id, string oldPasswordHash, string newPasswordHash)
        {
            // validations
            await ValidateInput(id, oldPasswordHash, newPasswordHash);

            var user = await userRepository
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == id && (u.PasswordHash == null || u.PasswordHash == oldPasswordHash));

            user.PasswordHash = newPasswordHash;

            await userRepository.SaveChangesAsync();
        }

        private async Task ValidateInput(Guid id, string oldPasswordHash, string newPasswordHash)
        {
            if (id == default) throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrEmpty(newPasswordHash)) throw new ArgumentNullException(nameof(newPasswordHash));

            if (!await userRepository.AnyAsync(u => u.Id == id && (u.PasswordHash == null || u.PasswordHash == oldPasswordHash)))
            {
                if (string.IsNullOrEmpty(oldPasswordHash))
                    throw new BusinessException($"User with id {id} not found");
                else
                    throw new BusinessException("Invalid id or password");
            }
        }

        #endregion Methods
    }
}
