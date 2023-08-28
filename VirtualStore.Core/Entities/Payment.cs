using System.ComponentModel.DataAnnotations.Schema;
using VirtualStore.Core.Enums;

namespace VirtualStore.Core.Entities;

public abstract class Payment
{
    [Column("state_payment")] public StatePaymentEnum StatePayment { get; private set; }
    [Column("order_id")] public int OrderId { get; private set; }
    public Order Order { get; private set; }
}