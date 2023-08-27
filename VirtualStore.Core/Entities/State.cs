namespace VirtualStore.Core.Entities;

public class State : BaseEntity
{
    public string Name { get; private set; }
    public List<City> Cities { get; private set; } = new List<City>();
}