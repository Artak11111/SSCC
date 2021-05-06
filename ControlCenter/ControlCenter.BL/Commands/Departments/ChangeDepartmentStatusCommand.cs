using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Departments
{
    public class ChangeDepartmentStatusCommand
    {
        #region Fields

        private readonly IRepository<DisabledDepartment> disabledDepartmentRepository;
        private readonly IRepository<Department> departmentRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public ChangeDepartmentStatusCommand(IUserInfoProvider userInfoProvider, IRepository<Department> departmentRepository, IRepository<DisabledDepartment> disabledDepartmentRepository)
        {
            this.disabledDepartmentRepository = disabledDepartmentRepository;
            this.departmentRepository = departmentRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task Execute(Guid departmentId)
        {
            // validations
            await ValidateInput(departmentId);

            var disabledDepartment = await disabledDepartmentRepository
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (disabledDepartment != null)
            {
                disabledDepartmentRepository.Remove(disabledDepartment);
            }
            else
            {
                disabledDepartmentRepository.Add(new DisabledDepartment
                {
                    DepartmentId = departmentId,
                    UserId = userInfoProvider.CurrentUserId
                });
            }

            await disabledDepartmentRepository.SaveChangesAsync();
        }

        private async Task ValidateInput(Guid departmentId)
        {
            if (departmentId == default) throw new ArgumentNullException(nameof(departmentId));

            if (!await departmentRepository.AnyAsync(d =>d.Id== departmentId))
                throw new BusinessException("Department not found");
        }

        #endregion Methods
    }
}
