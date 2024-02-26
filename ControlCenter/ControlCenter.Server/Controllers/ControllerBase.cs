using ControlCenter.BL.Exceptions;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using System;
using ControlCenter.Contracts.Contracts;
using ControlCenter.Server.Models;

namespace ControlCenter.Server.Controllers
{
    public class ControllerBase : Controller
    {
        public Task<IActionResult> Run<TInput, TResult>(ICommand<TInput, TResult> action, TInput input)
        {
            return Run(async () => Ok(await action.ExecuteAsync(input)));
        }

        public Task<IActionResult> Run<TInput>(ICommand<TInput> action, TInput input)
        {
            return Run(async () =>
            {
                await action.ExecuteAsync(input);
                return Ok();
            });
        }

        public Task<IActionResult> Run<TResult>(IQuery<TResult> action)
        {
            return Run(async () => Ok(await action.ExecuteAsync()));
        }

        private async Task<IActionResult> Run(Func<Task<IActionResult>> task)
        {
            try
            {
                return await task();
            }
            catch (BusinessException businessException)
            {
                return BadRequest(new ErrorResult
                {
                    Exception = businessException,
                    Message = businessException.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResult
                {
                    Exception = ex,
                    Message = "Internal server error"
                });
            }
        }
    }
}
