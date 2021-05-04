using ControlCenter.Abstractions;
using ControlCenter.BL.Exceptions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Departments
{
    public class GetDepartmentsQuery
    {
        #region Fields

        private readonly IRepository<Department> departmentRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUserInfoProvider userInfoProvider;

        #endregion Fields

        #region Constructor

        public GetDepartmentsQuery(IUserInfoProvider userInfoProvider, IRepository<User> userRepository, IRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            this.userRepository = userRepository;
            this.userInfoProvider = userInfoProvider;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<Department>> Execute()
        {
            // validations
            await ValidateInput();

            return await departmentRepository.AsQueryable()
                .OrderBy(d=> d.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task ValidateInput()
        {
            if (!await userRepository.AnyAsync(u => u.Id == userInfoProvider.CurrentUserId))
                throw new BusinessException("User not found");
        }

        #endregion Methods
    }
}
