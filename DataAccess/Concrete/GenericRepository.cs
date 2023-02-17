using DataAccess.AppDbContext;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Abstract.IRepository;

namespace DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDb_Context _appDbContext;

        public GenericRepository(AppDb_Context appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _appDbContext.Set<TEntity>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _appDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
