using ControlCenter.Contracts.Contracts;

using System.Threading.Tasks;

namespace ControlCenter.BL.Commands.Common
{
    public abstract class CommandBase<TInput> : ICommand<TInput>
    {
        public abstract Task ExecuteAsync(TInput input);

        protected virtual Task ValidateAsync(TInput input)
        {
            return Task.CompletedTask;
        }
    }

    public abstract class CommandBase<TInput, TResult> : ICommand<TInput, TResult>
    {
        public abstract Task<TResult> ExecuteAsync(TInput input);

        protected virtual Task ValidateAsync(TInput input)
        {
            return Task.CompletedTask;
        }
    }
}
