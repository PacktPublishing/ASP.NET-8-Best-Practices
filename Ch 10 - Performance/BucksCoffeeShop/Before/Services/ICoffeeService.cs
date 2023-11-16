using BucksCoffeeShopBefore.Entities;

namespace BucksCoffeeShopBefore.Services;

public interface ICoffeeService
{
    Task<List<Product>> GetAllAsync();
}