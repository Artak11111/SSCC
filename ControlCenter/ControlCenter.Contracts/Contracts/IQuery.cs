using System.Threading.Tasks;

namespace ControlCenter.Contracts.Contracts
{
    public interface IQuery<TResult>
    {
        Task<TResult> ExecuteAsync();
    }
}
