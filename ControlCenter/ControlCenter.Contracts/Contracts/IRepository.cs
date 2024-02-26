using ControlCenter.Entities.Models;
using System.Linq.Expressions;

namespace ControlCenter.Contracts.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> AsQueryable();

        Task<List<TEntity>> ToListAsync();

        Task SaveChangesAsync();
    }
}
