namespace BucksCoffeeShopAfter.Services;

public class Product
{
    public Guid Id { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
}
