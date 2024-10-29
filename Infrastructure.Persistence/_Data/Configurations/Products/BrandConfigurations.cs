using Domain.Entities;
using Infrastructure.Persistence._Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence._Data.Configurations.Products
{
    internal class BrandConfigurations :BaseEntityConfigurations<ProductBrand,int>
    {
        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);
            builder.Property(B => B.Name).IsRequired();
        }
    }
}
