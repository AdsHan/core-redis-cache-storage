using CDI.Catalog.API.Service;
using CDI.Catalog.Domain.Repositories;
using CDI.Catalog.Infrastructure.Data;
using CDI.Catalog.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CDI.Catalog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("ProductsDB"));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddTransient<ProductPopulateService>();

            return services;
        }

    }
}