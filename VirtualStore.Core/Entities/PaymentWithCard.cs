using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualStore.Core.Entities;

public class PaymentWithCard : Payment
{
    [Column("number_of_parcels")] public int NumberOfParcels { get; private set; }
}