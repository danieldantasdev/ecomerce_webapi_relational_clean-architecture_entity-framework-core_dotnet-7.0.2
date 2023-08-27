namespace VirtualStore.Core.Entities;

public class PagamentoComCartao : Pagamento
{
    public int NumeroDeParcelas { get; private set; }
}