using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class State : BaseEntity
{
    [Column("name")] public string Name { get; private set; }
    public List<City> Cities { get; private set; } = new List<City>();
}