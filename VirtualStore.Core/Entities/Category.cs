using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class Category : BaseEntity
{
    [Column("name")]
    public string Name { get; private set; }
    public List<Product> Products { get; private set; } = new List<Product>();
}