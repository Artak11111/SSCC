using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ControlCenter.BL.Queries.Departments;
using ControlCenter.BL.Commands.Departments;
using System;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DepartmentsController : ControllerBase
    {
        #region Commands and Queries

        private readonly ChangeDepartmentStatusCommand ChangeDepartmentStatusCommand;
        private readonly GetDisabledDepartmentsQuery GetDisabledDepartmentsQuery;
        private readonly GetDepartmentsQuery GetDepartmentsQuery;

        #endregion Commands and Queries

        #region Constructor

        public DepartmentsController(ChangeDepartmentStatusCommand changeDepartmentStatusCommand, 
            GetDisabledDepartmentsQuery getDisabledDepartmentsQuery, 
            GetDepartmentsQuery getDepartmentsQuery)
        {
            GetDepartmentsQuery = getDepartmentsQuery;
            ChangeDepartmentStatusCommand = changeDepartmentStatusCommand;
            GetDisabledDepartmentsQuery = getDisabledDepartmentsQuery;
        }

        #endregion Constructor

        #region Actions

        [HttpGet]
        [Route("get-departments")]
        public Task<IActionResult> GetDepartments()
        {
            return Run(GetDepartmentsQuery);
        }

        [HttpGet]
        [Route("get-disabled-departments")]
        public Task<IActionResult> GetDisabledDepartments()
        {
            return Run(GetDisabledDepartmentsQuery);
        }

        [HttpPost]
        [Route("change-department-status")]
        public Task<IActionResult> ChangeDepartmentStatus(Guid departmentId)
        {
            return Run(ChangeDepartmentStatusCommand, departmentId);
        }

        #endregion Actions
    }
}
