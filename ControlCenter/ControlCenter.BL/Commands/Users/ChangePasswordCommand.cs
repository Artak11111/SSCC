using ControlCenter.BL.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ControlCenter.BL.Commands.Common;
using ControlCenter.BL.Commands.Users.Models;
using ControlCenter.Entities.Models;
using ControlCenter.Contracts.Contracts;
using ControlCenter.BL.Commands.Notifications;

namespace ControlCenter.BL.Commands.Users
{
    public class ChangePasswordCommand : CommandBase<ChangePasswordInputModel>
    {
        #region Constructor

        public ChangePasswordCommand(IRepository<User> userRepository, IUserInfoProvider userInfoProvider)
        {
            UserRepository = userRepository;
            UserInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Properties

        protected IUserInfoProvider UserInfoProvider { get; }

        protected IRepository<User> UserRepository { get; }

        protected IRepository<Department> DepartmentRepository { get; }

        protected CreateNotificationCommand CreateNotificationCommand { get; }

        #endregion Properties

        #region Methods

        public override async Task ExecuteAsync(ChangePasswordInputModel input)
        {
            await ValidateAsync(input);

            var user = await UserRepository
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == UserInfoProvider.CurrentUserId && (u.PasswordHash == null || u.PasswordHash == input.OldPassword));

            user.PasswordHash = input.NewPassword;

            await UserRepository.SaveChangesAsync();
        }

        protected override async Task ValidateAsync(ChangePasswordInputModel input)
        {
            if (string.IsNullOrEmpty(input.NewPassword)) throw new ArgumentNullException(nameof(input.NewPassword));

            if (!await UserRepository.AnyAsync(u => u.Id == UserInfoProvider.CurrentUserId && (u.PasswordHash == null || u.PasswordHash == input.OldPassword)))
            {
                if (string.IsNullOrEmpty(input.OldPassword))
                    throw new BusinessException($"User not found");
                    
                throw new BusinessException("Invalid id or password");
            }
        }

        #endregion Methods
    }
}
