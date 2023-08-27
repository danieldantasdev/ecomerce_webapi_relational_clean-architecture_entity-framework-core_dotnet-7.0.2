namespace VirtualStore.Core.Entities;

public class PagamentoComBoleto : Pagamento
{
    public DateTime DataExpiracao { get; private set; }
    public DateTime DataPagamento { get; private set; }
}