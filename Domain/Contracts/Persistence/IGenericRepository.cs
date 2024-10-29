using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Persistence
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool AsNoTracking);
        Task<TEntity?> GetAsync(TKey id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void DeleteAsync(TEntity entity);





    }
}
