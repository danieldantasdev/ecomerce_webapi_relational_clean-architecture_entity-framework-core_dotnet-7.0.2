namespace VirtualStore.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public List<Category> Categories { get; private set; } = new List<Category>();
    public List<OrderItem> Itens { get; private set; } = new List<OrderItem>();
}