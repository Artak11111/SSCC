using ControlCenter.Contracts.Contracts;

using System.Threading.Tasks;

namespace ControlCenter.BL.Queries.Common
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        public abstract Task<TResult> ExecuteAsync();
    }
}
