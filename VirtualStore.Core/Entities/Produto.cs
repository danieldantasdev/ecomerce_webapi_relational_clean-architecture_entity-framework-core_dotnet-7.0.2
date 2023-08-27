namespace VirtualStore.Core.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}