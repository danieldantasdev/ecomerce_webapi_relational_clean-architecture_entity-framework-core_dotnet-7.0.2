namespace VirtualStore.Core.Entities;

public class ItemPedido
{
    public int PedidoId { get; private set; }
    public Pedido Pedido { get; private set; }
    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public double Desconto { get; private set; }
    public int Quantidade { get; private set; }
    public double Preco { get; private set; }
}