using Domain.Common;
using Domain.Contracts.Persistence;
using Infrastructure.Persistence._Data;
using Infrastructure.Persistence.GenericRepository;
using System.Collections.Concurrent;

namespace Infrastructure.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        private readonly ConcurrentDictionary<string, object> _repository;
        public UnitOfWork(StoreDbContext dbContext)
        {
           _dbContext = dbContext;
            _repository = new ConcurrentDictionary<string, object>();
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
           where TEntity : BaseAuditableEntity<TKey>
           where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity,TKey>) _repository.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(_dbContext));
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }


    }
}
