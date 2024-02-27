using System.Threading.Tasks;

namespace ControlCenter.Contracts.Contracts
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }

    public interface ICommand<TInput>
    {
        Task ExecuteAsync(TInput input);
    }

    public interface ICommand<TInput, TResult>
    {
        Task<TResult> ExecuteAsync(TInput input);
    }
}
