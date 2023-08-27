namespace VirtualStore.Core.Entities;

public class Order : BaseEntity
{
    public DateTime Instant { get; private set; }
    public Payment Payment { get; private set; }
    public int ClientId { get; private set; }
    public Client Client { get; private set; }
    public Address DeliveryAddress { get; private set; }
    public int DeliveryAddressId { get; private set; }
    public List<OrderItem> Itens { get; private set; } = new List<OrderItem>();
}