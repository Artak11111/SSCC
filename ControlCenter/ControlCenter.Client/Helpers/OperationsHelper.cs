using System;
using System.Threading.Tasks;

namespace ControlCenter.Client.Helpers
{
    public static class OperationsHelper
    {
        public static async Task RunAsync(Action operation)
        {
            try
            {
                await Task.Run(operation);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                
            }
        }

        public static async void RunParallel(Action operation)
        {
            try
            {
                await Task.Run(operation);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {

            }
        }

        public static async Task<T> RunAsync<T>(Func<T> operation)
        {
            T result = default;

            try
            {
                result = await Task.Run(operation);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {
               
            }

            return result;
        }
    }
}
