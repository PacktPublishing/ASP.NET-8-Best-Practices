
namespace BucksCoffeeShopBefore.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Image { get; set; } = null!;

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public bool Available { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}