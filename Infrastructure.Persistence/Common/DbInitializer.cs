using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.Persistence;
using Infrastructure.Persistence._Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Common
{
    public abstract class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _dbContext;

        public DbInitializer(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task InitializeAsync()
        {
            var pendingMigration = await _dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigration.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }

        public abstract Task Seeds();

    }
}
