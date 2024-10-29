using Application.Abstraction;
using Domain.Contracts.Persistence;
using Infrastructure.Persistence._Data;
using Infrastructure.Persistence._Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StoreContext"));
                 
            });
            services.AddScoped<IStoreDbInitializer, StoreDbInitializer>();
            services.AddScoped<ISaveChangesInterceptor, CustomSaveChangeInterceptor>();

            return services;
        }
    }
}
