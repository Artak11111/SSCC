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
    public class DepartmentsController : Controller
    {
        #region Commands and Queries

        private readonly ChangeDepartmentStatusCommand changeDepartmentStatusCommand;
        private readonly GetDisabledDepartmentsQuery getDisabledDepartmentsQuery;
        private readonly GetDepartmentsQuery getDepartmentsQuery;
        private readonly TaskExecutor.TaskExecutor taskExecutor;

        #endregion Commands and Queries

        #region Constructor

        public DepartmentsController(ChangeDepartmentStatusCommand changeDepartmentStatusCommand, GetDisabledDepartmentsQuery getDisabledDepartmentsQuery, GetDepartmentsQuery getDepartmentsQuery, TaskExecutor.TaskExecutor taskExecutor)
        {
            this.getDepartmentsQuery = getDepartmentsQuery;
            this.changeDepartmentStatusCommand = changeDepartmentStatusCommand;
            this.getDisabledDepartmentsQuery = getDisabledDepartmentsQuery;
            this.taskExecutor = taskExecutor;
        }

        #endregion Constructor

        #region Actions

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var result = await taskExecutor.Execute(async () =>
            {
                return await getDepartmentsQuery.Execute();
            });

            if (result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpGet]
        [Route("GetDisabledDepartments")]
        public async Task<IActionResult> GetDisabledDepartments()
        {
            var result = await taskExecutor.Execute(async () =>
            {
                return await getDisabledDepartmentsQuery.Execute();
            });

            if (result.ErrorMessage == null)
            {
                return Json(result.Result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Route("ChangeDepartmentStatus")]
        public async Task<IActionResult> ChangeDepartmentStatus(Guid departmentId)
        {
            var result = await taskExecutor.Execute(async () =>
            {
                await changeDepartmentStatusCommand.Execute(departmentId);
            });

            if (result.ErrorMessage == null)
            {
                return Ok();
            }

            return BadRequest(result.ErrorMessage);
        }

        #endregion Actions
    }
}
