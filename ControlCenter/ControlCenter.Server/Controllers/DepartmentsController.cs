using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ControlCenter.BL.Queries.Departments;

namespace ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DepartmentsController : Controller
    {
        #region Commands and Queries

        private readonly GetDepartmentsQuery getDepartmentsQuery;
        private readonly TaskExecutor.TaskExecutor taskExecutor;

        #endregion Commands and Queries

        #region Constructor

        public DepartmentsController(GetDepartmentsQuery getDepartmentsQuery, TaskExecutor.TaskExecutor taskExecutor)
        {
            this.getDepartmentsQuery = getDepartmentsQuery;
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

        #endregion Actions
    }
}
