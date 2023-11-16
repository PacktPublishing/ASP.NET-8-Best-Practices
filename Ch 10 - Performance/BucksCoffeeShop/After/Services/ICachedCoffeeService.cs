namespace BucksCoffeeShopAfter.Services;

public interface ICachedCoffeeService
{
    List<Product> GetAll(bool reload = false);
}