using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class PaymentWithSlip : Payment
{
    [Column("expiration_date")] public DateTime ExpirationDate { get; private set; }
    [Column("payment_date")] public DateTime PaymentDate { get; private set; }
}