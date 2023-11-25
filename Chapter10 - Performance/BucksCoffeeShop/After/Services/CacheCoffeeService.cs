using Microsoft.Extensions.Caching.Memory;

namespace BucksCoffeeShopAfter.Services;

public class CacheCoffeeService : CoffeeService, ICachedCoffeeService
{
    private const string keyCoffeeList = "EntireCoffeeList";

    private readonly IMemoryCache _cache;

    public CacheCoffeeService(IBucksDbContext dbContext, 
        IMemoryCache cache) 
        : base(dbContext)
    {
        _cache = cache;
    }

    public List<Product> GetAll(bool reload = false)
    {
        // If we can't find it in the cache...
        if (!_cache.TryGetValue(keyCoffeeList, out List<Product> coffees) || reload)
        {
            coffees = base.GetAll();

            _cache.Set(keyCoffeeList, coffees,
                new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60)) // 1min
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600)) // 6min
                    .SetPriority(CacheItemPriority.Normal)
            );
        }

        return coffees;
    }
}