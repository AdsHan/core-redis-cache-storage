using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CDI.CacheStorage
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var objectString = await _distributedCache.GetStringAsync(key);

            if (string.IsNullOrWhiteSpace(objectString))
            {

                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(objectString);
        }

        public async Task SetAsync<T>(string key, T data)
        {
            var memoryCacheEntryOptions = new DistributedCacheEntryOptions
            {
                // Tempo abosluto que o registro de cache vai expirar
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                // Tempo máximo que o registro pode ficar sem ser acessado. Após será excluído
                SlidingExpiration = TimeSpan.FromSeconds(1200)
            };

            var objectString = JsonConvert.SerializeObject(data);

            await _distributedCache.SetStringAsync(key, objectString, memoryCacheEntryOptions);
        }
    }
}