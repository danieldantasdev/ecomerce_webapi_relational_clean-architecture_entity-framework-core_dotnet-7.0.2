namespace VirtualStore.Core.Entities;

public class Estado
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Cidade> Cidades { get; set; } = new List<Cidade>();
}