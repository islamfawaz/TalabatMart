using Domain.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Persistence._Data
{
    public class StoreDbInitializer : DbInitializer, IStoreDbInitializer
    {
        private readonly StoreDbContext _dbContext;

        public StoreDbInitializer(StoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task Seeds()
        {

           

            if (!_dbContext.Brands.Any())
            {
                var brandData = await File.ReadAllTextAsync("C:\\Users\\TECH VALLEY\\source\\repos\\Talabat Mart\\Infrastructure.Persistence\\_Data\\Seeds\\brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                if (brands?.Count > 0)
                {
                    await _dbContext.AddRangeAsync(brands);
                    await _dbContext.SaveChangesAsync();
                }
            }

            if (!_dbContext.Categories.Any())
            {
                var categoriesData = await File.ReadAllTextAsync("C:\\Users\\TECH VALLEY\\source\\repos\\Talabat Mart\\Infrastructure.Persistence\\_Data\\Seeds\\categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                if (categories?.Count > 0)
                {
                    await _dbContext.AddRangeAsync(categories);
                    await _dbContext.SaveChangesAsync();
                }
            }


            if (!_dbContext.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("C:\\Users\\TECH VALLEY\\source\\repos\\Talabat Mart\\Infrastructure.Persistence\\_Data\\Seeds\\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count > 0)
                {
                    await _dbContext.AddRangeAsync(products);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

    }
}
