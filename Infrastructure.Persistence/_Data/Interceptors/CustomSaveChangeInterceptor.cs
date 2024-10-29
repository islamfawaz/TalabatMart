using Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstraction;

namespace Infrastructure.Persistence._Data.Interceptors
{
    internal class CustomSaveChangeInterceptor : SaveChangesInterceptor
    {
        private readonly ILoggedInUserService _loggedInUser;

        public CustomSaveChangeInterceptor(ILoggedInUserService loggedInUser)
        {
            _loggedInUser = loggedInUser;
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext ? dbContext)
        {
            if (dbContext == null) 
                return;
            foreach (var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity<int>>().
                Where((entity) => entity.State is EntityState.Added or EntityState.Modified))
            {
                if (entry.State is EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy =_loggedInUser.UserId;
                    entry.Entity.LastModifiedOn= DateTime.UtcNow;
                }
                entry.Entity.CreatedBy = _loggedInUser.UserId;
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

        }
    }
}
