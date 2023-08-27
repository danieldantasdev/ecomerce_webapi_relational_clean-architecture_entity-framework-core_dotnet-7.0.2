namespace VirtualStore.Core.Entities;

public class City : BaseEntity
{
    public string Name { get; private set; }
    public int StateId { get; private set; }
    public State State { get; private set; }
}