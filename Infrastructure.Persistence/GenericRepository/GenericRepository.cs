using Domain.Common;
using Domain.Contracts.Persistence;
using Infrastructure.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.GenericRepository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext  dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking=false)
        {
            return  AsNoTracking ?    await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync() : await _dbContext.Set<TEntity>().ToListAsync();
         }

        public async Task<TEntity?> GetAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task AddAsync(TEntity entity)
        {
         await   _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

     

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
