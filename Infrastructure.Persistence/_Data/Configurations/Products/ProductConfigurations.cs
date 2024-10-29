using Domain.Entities;
using Infrastructure.Persistence._Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence._Data.Configurations.Products
{
    public class ProductConfigurations :BaseEntityConfigurations<Product,int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(P => P.Name).HasMaxLength(100).IsRequired();
            builder.Property(P => P.NormalizedName).HasMaxLength(100).IsRequired();

            builder.Property(P=>P.Description).IsRequired();

            builder.Property(P => P.Price) .HasColumnType("decimal(9,2)");
           
            builder.HasOne(P=>P.Brand).WithMany()
                .HasForeignKey(P=>P.BrandId).OnDelete(DeleteBehavior.SetNull);


            builder.HasOne(P => P.Category).WithMany()
                .HasForeignKey(P => P.CategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
