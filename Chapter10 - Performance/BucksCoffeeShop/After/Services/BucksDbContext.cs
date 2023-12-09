using Microsoft.EntityFrameworkCore;

namespace BucksCoffeeShopAfter.Services;

public class BucksDbContext : IBucksDbContext
{
    public DbSet<Product> Coffees { get; set; }
}