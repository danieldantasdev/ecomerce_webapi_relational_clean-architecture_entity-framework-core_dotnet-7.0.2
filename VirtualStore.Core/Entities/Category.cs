namespace VirtualStore.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public List<Product> Products { get; private set; } = new List<Product>();
}