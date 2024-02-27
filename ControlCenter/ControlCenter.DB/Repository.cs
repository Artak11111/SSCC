using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ControlCenter.Contracts.Contracts;
using ControlCenter.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlCenter.DB
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected ControlCenterDbContext Context { get; set; }
        
        public Repository(ControlCenterDbContext context)
        {
            this.Context = context;

            CheckDbSet();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            return Context.Set<TEntity>().Include(navigationPropertyPath);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().AnyAsync(predicate);
        }
        
        public IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public Task<List<TEntity>> ToListAsync()
        {
            return Context.Set<TEntity>().ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        private void CheckDbSet()
        {
            try
            {
                Context.Set<TEntity>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
