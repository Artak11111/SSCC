using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ControlCenter.Abstractions;
using ControlCenter.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlCenter.DB
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly AppDbContext context;
        
        public Repository(AppDbContext context)
        {
            this.context = context;

            CheckDbSet();
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            return context.Set<TEntity>().Include(navigationPropertyPath);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AnyAsync(predicate);
        }
        
        public IQueryable<TEntity> AsQueryable()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public async Task<List<TEntity>> ToListAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        private void CheckDbSet()
        {
            try
            {
                context.Set<TEntity>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}