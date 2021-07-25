using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CDI.CacheStorage.Configuration
{
    public static class RedisConfig
    {
        public static IServiceCollection AddRedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "CacheStorage";
                options.Configuration = "localhost,port:6379,password=MyPass@word";
            });

            services.AddTransient<ICacheService, CacheService>();

            return services;
        }

    }
}