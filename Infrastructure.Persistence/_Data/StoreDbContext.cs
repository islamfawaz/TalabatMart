using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence._Data
{
    public class StoreDbContext :DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> dbContext):base(dbContext)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);
        }
        public DbSet<Product>  Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }

        public DbSet<ProductCategory> Categories { get; set; }

      

    }
}
