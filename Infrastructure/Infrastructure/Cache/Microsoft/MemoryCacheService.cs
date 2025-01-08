using Application.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Cache.Microsoft;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public  T GetAll<T>(string key)
    {
        return _memoryCache.TryGetValue(key, out T value) ? value : default;
    }


    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }
	

    public void Set<T>(string key, T value, TimeSpan expiration)
    {

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        };

        _memoryCache.Set(key, value, cacheEntryOptions);

    }
}