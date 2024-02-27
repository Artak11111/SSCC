using ControlCenter.BL.Queries.Common;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Departments
{
    public class GetDisabledDepartmentsQuery : QueryBase<List<DisabledDepartment>>
    {
        #region Constructor

        public GetDisabledDepartmentsQuery(IRepository<User> userRepository,
            IUserInfoProvider userInfoProvider,
            IRepository<DisabledDepartment> departmentRepository)
        {
            DepartmentRepository = departmentRepository;
            UserRepository = userRepository;
            UserInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<DisabledDepartment> DepartmentRepository { get; }

        protected IRepository<User> UserRepository { get; }

        protected IUserInfoProvider UserInfoProvider { get; }

        #endregion Properties

        #region Methods

        public override Task<List<DisabledDepartment>> ExecuteAsync()
        {
            return DepartmentRepository.AsQueryable()
                .Where(d => d.UserId == UserInfoProvider.CurrentUserId)
                .OrderBy(d => d.Department.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion Methods
    }
}
