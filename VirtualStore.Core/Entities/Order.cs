using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class Order : BaseEntity
{
    [Column("instant")] public DateTime Instant { get; private set; }
    public Payment Payment { get; private set; }
    [Column("client_id")] public int ClientId { get; private set; }
    public Client Client { get; private set; }
    [Column("delivery_address_id")] public int DeliveryAddressId { get; private set; }
    public Address DeliveryAddress { get; private set; }
    public List<OrderItem> Itens { get; private set; } = new List<OrderItem>();
}