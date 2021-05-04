using ControlCenter.Abstractions;
using ControlCenter.BL.Commands.Notifications;
using ControlCenter.BL.Commands.Notifications.Models;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlCenter.BL.Commands.Users
{
    public class ChangeDepartmentCommand
    {
        #region Fields

        private readonly IRepository<User> userRepository;
        private readonly IRepository<Department> departmentRepository;
        private readonly IUserInfoProvider userInfoProvider;
        private readonly CreateNotificationCommand createNotificationCommand;

        #endregion Fields

        #region Constructor

        public ChangeDepartmentCommand(IUserInfoProvider userInfoProvider, IRepository<User> userRepository, IRepository<Department> departmentRepository, CreateNotificationCommand createNotificationCommand)
        {
            this.userRepository = userRepository;
            this.departmentRepository = departmentRepository;
            this.createNotificationCommand = createNotificationCommand;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute(Guid id, Guid departmentId)
        {
            // validations
            await ValidateInput(id, departmentId);

            var user = await userRepository
                .Include(u=>u.Department)
                .FirstOrDefaultAsync(u => u.Id == id);

            var oldDepartment = user.Department;
            var newDepartment = await departmentRepository
                .FirstOrDefaultAsync(d=>d.Id==departmentId);

            user.DepartmentId = departmentId;

            await userRepository.SaveChangesAsync();

            await NotifyManagers(user, oldDepartment, newDepartment);
        }

        private async Task NotifyManagers(User user, Department oldDepartment, Department newDepartment)
        {
            await createNotificationCommand.Execute(new CreateNotificationInputModel
            {
                DateTime = DateTimeOffset.UtcNow,
                Message = $"Employee {user.Name} was moved from {oldDepartment.Name} to {newDepartment.Name}",
                Repeat = null,
                // little hack: 
                // As we know that only managers can change department, then after validation we are sure that current users department is management
                // so we can send notification to management department
                TargetDepartments = new List<Guid>
                {
                    userInfoProvider.CurrentDepartmentId
                }
            });
        }

        private async Task ValidateInput(Guid id, Guid departmentId)
        {
            if (id == default) throw new ArgumentNullException(nameof(id));
            if (departmentId == default) throw new ArgumentNullException(nameof(departmentId));
            if (id == departmentId) throw new BusinessException("New department must be different");

            if (!await userRepository.AnyAsync(u => u.Id == id))
                throw new BusinessException($"User not found");

            if (!await departmentRepository.AnyAsync(d => d.Id == userInfoProvider.CurrentDepartmentId && d.Name == "Management"))
                throw new BusinessException($"Department not found");
        }

        #endregion Methods
    }
}
