using Microsoft.EntityFrameworkCore;

namespace BucksCoffeeShopAfter.Services;

public interface IBucksDbContext
{
    DbSet<Product> Coffees { get; set; }
}