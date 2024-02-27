using ControlCenter.BL.Commands.Notifications;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlCenter.Entities.Models;
using ControlCenter.Contracts.Contracts;
using ControlCenter.BL.Commands.Users.Models;
using ControlCenter.BL.Commands.Common;

namespace ControlCenter.BL.Commands.Users
{
    public class ChangeDepartmentCommand : CommandBase<ChangeDepartmentInputModel>
    {
        #region Constructor

        public ChangeDepartmentCommand(IUserInfoProvider userInfoProvider,
            IRepository<User> userRepository, 
            IRepository<Department> departmentRepository, 
            CreateNotificationCommand createNotificationCommand)
        {
            UserRepository = userRepository;
            DepartmentRepository = departmentRepository;
            CreateNotificationCommand = createNotificationCommand;
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

        public override async Task ExecuteAsync(ChangeDepartmentInputModel input)
        {
            await ValidateAsync(input);

            var user = await UserRepository
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == UserInfoProvider.CurrentUserId);

            var oldDepartment = user.Department;
            var newDepartment = await DepartmentRepository
                .FirstOrDefaultAsync(d => d.Id == input.NewDepartmentId);

            user.DepartmentId = input.NewDepartmentId;

            await UserRepository.SaveChangesAsync();

            await NotifyManagers(user, oldDepartment, newDepartment);
        }

        private async Task NotifyManagers(User user, Department oldDepartment, Department newDepartment)
        {
            await CreateNotificationCommand.ExecuteAsync(new CreateNotificationInputModel
            {
                DateTime = DateTime.UtcNow,
                Message = $"Employee {user.Name} was moved from {oldDepartment.Name} to {newDepartment.Name}",
                Repeat = RepeatInterval.Never,
                // little hack: 
                // As we know that only managers can change department, then after validation we are sure that current users department is management
                // so we can send notification to management department
                TargetDepartments = new List<Guid>
                {
                    UserInfoProvider.CurrentDepartmentId
                }
            });
        }

        protected override async Task ValidateAsync(ChangeDepartmentInputModel input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            if (input.OldDepartmentId == Guid.Empty) throw new ArgumentNullException(nameof(input.OldDepartmentId));

            if (input.NewDepartmentId == Guid.Empty) throw new ArgumentNullException(nameof(input.NewDepartmentId));

            if (input.OldDepartmentId == input.NewDepartmentId) throw new BusinessException("New department must be different");

            if (!await DepartmentRepository.AnyAsync(d => d.Id == UserInfoProvider.CurrentDepartmentId && d.Name == "Management"))
                throw new BusinessException($"Management department with id {UserInfoProvider.CurrentDepartmentId} not found");
        }

        #endregion Methods
    }
}
