using Microsoft.VisualBasic;
using VirtualStore.Core.Enums;

namespace VirtualStore.Core.Entities;

public class Client : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string CpfOrCnpj { get; private set; }
    public TypeClientEnum Type { get; private set; }
    public List<Address> Addresss { get; private set; } = new List<Address>();
    public List<string> Phones { get; private set; } = new List<string>();
    public List<Order> Orders { get; private set; } = new List<Order>();
}