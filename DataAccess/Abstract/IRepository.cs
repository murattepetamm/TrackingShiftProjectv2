using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository
    {
        public interface IRepository<TEntity> where TEntity : BaseEntity
        {
            IEnumerable<TEntity> GetAll();
            Task<TEntity> GetById(int id);
            Task Create(TEntity entity);
            Task Update(int id, TEntity entity);
            Task Delete(int id);
        }
    }
}
