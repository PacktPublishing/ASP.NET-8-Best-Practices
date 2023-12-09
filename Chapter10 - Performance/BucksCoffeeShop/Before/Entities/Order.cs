
namespace BucksCoffeeShopBefore.Entities;

public partial class Order
{
    public Guid Id { get; set; }

    public DateTimeOffset OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}