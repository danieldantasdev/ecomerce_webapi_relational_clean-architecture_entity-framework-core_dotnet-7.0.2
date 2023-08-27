using Microsoft.VisualBasic;
using VirtualStore.Core.Enums;

namespace VirtualStore.Core.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CpfOuCnpj { get; set; }
    public TipoClienteEnum Tipo { get; set; }
    public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
    public List<Telefone> Telefones { get; set; } = new List<Telefone>();
    public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
}