using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TodoApp.Core.Entities;

namespace TodoApp.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public TContext Context { get { return new TContext(); } }
        public int Add(TEntity entity)
        {
            int rowsAdded = 0;
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                rowsAdded = context.SaveChanges();
            }
            return rowsAdded;
        }

        public int Delete(TEntity entity)
        {
            int rowsDeleted = 0;
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rowsDeleted = context.SaveChanges();
            }
            return rowsDeleted;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            int rowsUpdated = 0;
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                rowsUpdated = context.SaveChanges();
            }
            return entity;
        }
    }
}
