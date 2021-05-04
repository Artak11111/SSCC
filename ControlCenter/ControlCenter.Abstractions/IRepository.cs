using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ControlCenter.Entities;

namespace ControlCenter.Abstractions
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