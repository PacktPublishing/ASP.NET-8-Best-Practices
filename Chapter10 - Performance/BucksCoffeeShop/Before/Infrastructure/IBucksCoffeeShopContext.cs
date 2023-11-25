using BucksCoffeeShopBefore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BucksCoffeeShopBefore.Infrastructure;

public interface IBucksCoffeeShopContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderDetail> OrderDetails { get; set; }
    DbSet<Product> Products { get; set; }
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
}