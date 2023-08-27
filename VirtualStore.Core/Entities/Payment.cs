using VirtualStore.Core.Enums;

namespace VirtualStore.Core.Entities;

public abstract class Payment : BaseEntity
{
    public StatePaymentEnum Estado { get; private set; }
    public Order Order { get; private set; }
}