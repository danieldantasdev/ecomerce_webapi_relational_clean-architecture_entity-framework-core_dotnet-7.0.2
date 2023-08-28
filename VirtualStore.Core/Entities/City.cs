using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class City : BaseEntity
{
    [Column("name")] public string Name { get; private set; }
    [Column("state_id")] public int StateId { get; private set; }
    public State State { get; private set; }
}