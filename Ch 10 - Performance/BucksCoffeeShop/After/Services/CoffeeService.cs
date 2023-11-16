namespace BucksCoffeeShopAfter.Services;

public class CoffeeService : ICoffeeService
{
    private readonly IBucksDbContext _dbContext;

    public CoffeeService(IBucksDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Product> GetAll()
    {
        return _dbContext.Coffees.ToList();
    }
}