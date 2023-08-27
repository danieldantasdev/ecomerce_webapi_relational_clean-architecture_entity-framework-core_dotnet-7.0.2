namespace VirtualStore.Core.Entities;

public class OrderItem
{
    public Order Order { get; private set; }
    public Product Product { get; private set; }
    public double Discount { get; private set; }
    public int Quantity { get; private set; }
    public double Price { get; private set; }
}