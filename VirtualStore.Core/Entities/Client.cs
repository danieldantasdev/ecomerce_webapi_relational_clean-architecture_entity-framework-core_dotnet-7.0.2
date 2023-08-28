using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;
using VirtualStore.Core.Enums;

namespace VirtualStore.Core.Entities;

public class Client : BaseEntity
{
    [Column("name")] public string Name { get; private set; }
    [Column("email")] public string Email { get; private set; }
    [Column("cpf_or_cnpj")] public string CpfOrCnpj { get; private set; }
    [Column("type_client")] public TypeClientEnum TypeClient { get; private set; }
    public List<Address> Adresses { get; private set; } = new List<Address>();
    public List<Phone> Phones { get; private set; } = new List<Phone>();
    public List<Order> Orders { get; private set; } = new List<Order>();
}