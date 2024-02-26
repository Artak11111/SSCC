using ControlCenter.BL.Commands.Common;
using ControlCenter.BL.Exceptions;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

using System;
using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Departments
{
    public class ChangeDepartmentStatusCommand : CommandBase<Guid>
    {
        #region Constructor

        public ChangeDepartmentStatusCommand(IUserInfoProvider userInfoProvider, 
            IRepository<Department> departmentRepository, 
            IRepository<DisabledDepartment> disabledDepartmentRepository)
        {
            DisabledDepartmentRepository = disabledDepartmentRepository;
            DepartmentRepository = departmentRepository;
            UserInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<DisabledDepartment> DisabledDepartmentRepository { get; }

        protected IRepository<Department> DepartmentRepository { get; }

        protected IUserInfoProvider UserInfoProvider { get; }

        #endregion Properties

        #region Methods

        public override async Task ExecuteAsync(Guid departmentId)
        {
            await ValidateAsync(departmentId);

            var disabledDepartment = await DisabledDepartmentRepository
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (disabledDepartment != null)
            {
                DisabledDepartmentRepository.Remove(disabledDepartment);
            }
            else
            {
                DisabledDepartmentRepository.Add(new DisabledDepartment
                {
                    DepartmentId = departmentId,
                    UserId = UserInfoProvider.CurrentUserId
                });
            }

            await DisabledDepartmentRepository.SaveChangesAsync();
        }

        protected override async Task ValidateAsync(Guid departmentId)
        {
            if (departmentId == default) throw new ArgumentNullException(nameof(departmentId));

            if (!await DepartmentRepository.AnyAsync(d =>d.Id == departmentId))
                throw new BusinessException("Department not found");
        }

        #endregion Methods
    }
}
