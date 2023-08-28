using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class Product : BaseEntity
{
    [Column("name")] public string Name { get; private set; }
    [Column("price")] public double Price { get; private set; }
    public List<Category> Categories { get; private set; } = new List<Category>();
    public List<OrderItem> OrderItens { get; private set; } = new List<OrderItem>();
}