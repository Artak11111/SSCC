using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlCenter.BL.Queries.Common;
using ControlCenter.Entities.Models;
using ControlCenter.Contracts.Contracts;

namespace ControlCenter.BL.Queries.Departments
{
    public class GetDepartmentsQuery : QueryBase<List<Department>>
    {
        #region Constructor

        public GetDepartmentsQuery(IRepository<Department> departmentRepository)
        {
            DepartmentRepository = departmentRepository;
        }

        #endregion Constructor

        #region Properties

        protected IRepository<Department> DepartmentRepository { get; }

        #endregion Properties

        #region Methods

        public override Task<List<Department>> ExecuteAsync()
        {
            return DepartmentRepository.AsQueryable()
                .OrderBy(d=> d.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion Methods
    }
}
