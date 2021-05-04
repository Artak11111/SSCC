using ControlCenter.BL.Exceptions;
using System;
using System.Threading.Tasks;

namespace ControlCenter.Server.TaskExecutor
{
    public class TaskExecutor
    {
        #region Methods

        public async Task<TaskExecutionResult> Execute(Func<Task> task)
        {
            try
            {
                await task();

                return new TaskExecutionResult();
            }
            catch (BusinessException businessException)
            {
                return new TaskExecutionResult
                {
                    ErrorMessage = businessException.Message
                };
            }
            catch (Exception ex)
            {
                // log exception

                return new TaskExecutionResult
                {
                    ErrorMessage = "Internal server error"
                };
            }
        }

        public async Task<TaskExecutionResult<T>> Execute<T>(Func<Task<T>> task)
        {
            try
            {
                return new TaskExecutionResult<T>
                {
                    Result = await task()
            };
            }
            catch (BusinessException businessException)
            {
                return new TaskExecutionResult<T>
                {
                    ErrorMessage = businessException.Message
                };
            }
            catch (Exception ex)
            {
                // log exception

                return new TaskExecutionResult<T>
                {
                    ErrorMessage = "Internal server error"
                };
            }
        }

        #endregion Methods
    }
}
