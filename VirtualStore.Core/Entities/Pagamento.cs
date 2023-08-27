using VirtualStore.Core.Enums;

namespace VirtualStore.Core.Entities;

public abstract class Pagamento
{
    // public int Id { get; private set; }
    public EstadoPagamentoEnum Estado { get; private set; }
    public int PedidoId { get; private set; }
    public Pedido Pedido { get; private set; }
}