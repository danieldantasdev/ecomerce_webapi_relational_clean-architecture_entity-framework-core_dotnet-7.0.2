using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class OrderItem
{
    [Column("order_id")] public int OrderId { get; private set; }
    public Order Order { get; private set; }
    [Column("product_id")] public int ProductId { get; private set; }
    public Product Product { get; private set; }
    [Column("discount")] public double Discount { get; private set; }
    [Column("quantity")] public int Quantity { get; private set; }
    [Column("price")] public double Price { get; private set; }
}