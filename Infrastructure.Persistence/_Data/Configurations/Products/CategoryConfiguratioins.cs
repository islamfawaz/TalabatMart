using Domain.Entities;
using Infrastructure.Persistence._Data.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence._Data.Configurations.Products
{
    internal class CategoryConfiguratioins :BaseEntityConfigurations<ProductCategory,int>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);
            builder.Property(C => C.Name).IsRequired();
        }

    }
}
