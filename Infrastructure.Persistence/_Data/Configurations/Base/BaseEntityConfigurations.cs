using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence._Data.Configurations.Base
{
    public class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id).ValueGeneratedOnAdd();
            builder.Property(E => E.CreatedBy).IsRequired();
            builder.Property(E => E.LastModifiedBy).IsRequired();
            builder.Property(E => E.LastModifiedOn).IsRequired();
            builder.Property(E => E.CreatedOn).IsRequired();

        }
    }
}
