namespace VirtualStore.Core.Entities;

public class Pedido
{
    public int Id { get; private set; }
    public DateTime Instante { get; private set; }
    public Pagamento Pagamento { get; private set; }
    public int ClienteId { get; private set; }
    public Cliente Cliente { get; private set; }
    public int EnderecoEntregaId { get; private set; }
    public Endereco EnderecoEntrega { get; private set; }
    public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();
}