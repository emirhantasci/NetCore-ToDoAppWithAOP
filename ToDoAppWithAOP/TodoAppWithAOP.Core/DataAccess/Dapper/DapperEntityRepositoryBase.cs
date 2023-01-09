using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Core.DataAccess.Dapper
{
    public class DapperEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    {
        public int Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
