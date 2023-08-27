namespace VirtualStore.Core.Entities;

public class PaymentWithSlip : Payment
{
    public DateTime ExpirationDate { get; private set; }
    public DateTime PaymentDate { get; private set; }
}