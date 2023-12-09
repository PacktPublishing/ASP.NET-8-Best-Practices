using BucksCoffeeShopBefore.Entities;
using BucksCoffeeShopBefore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BucksCoffeeShopBefore.Services;

public class CoffeeService : ICoffeeService
{
    private readonly IBucksCoffeeShopContext _dbContext;

    public CoffeeService(IBucksCoffeeShopContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAllAsync() => await _dbContext.Products.ToListAsync();
}