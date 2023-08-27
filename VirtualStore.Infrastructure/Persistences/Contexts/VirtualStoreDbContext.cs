using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VirtualStore.Core.Entities;
using VirtualStore.Core.Enums;

namespace VirtualStore.Infrastructure.Persisntences.Context;

public class VirtualStoreDbContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItemPedidos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<PagamentoComBoleto> PagamentoComBoletos { get; set; }
    public DbSet<PagamentoComCartao> PagamentoComCartoes { get; set; }

    public VirtualStoreDbContext(DbContextOptions<VirtualStoreDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    void DefineNameTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().ToTable("categoria");
        modelBuilder.Entity<Produto>().ToTable("produto");
        modelBuilder.Entity<ItemPedido>().ToTable("item_pedido");
        modelBuilder.Entity<Pedido>().ToTable("pedido");
        modelBuilder.Entity<Pagamento>().ToTable("pagamento");
        modelBuilder.Entity<PagamentoComBoleto>().ToTable("pagamento_com_boleto");
        modelBuilder.Entity<PagamentoComCartao>().ToTable("pagamento_com_cartao");
        modelBuilder.Entity<Cliente>().ToTable("cliente");
        modelBuilder.Entity<Estado>().ToTable("estado");
        modelBuilder.Entity<Cidade>().ToTable("cidade");
        modelBuilder.Entity<Endereco>().ToTable("endereco");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DefineNameTables(modelBuilder);

        /*
         * 1 Categoria tem 1 ou * produtos
         * 1 Produto é de * Categorias
         */
        modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Produtos)
            .WithMany(p => p.Categorias)
            .UsingEntity(j => j.ToTable("categoria_produto"));

        /*
         * 1 Produto tem * Item de Pedido
         * 1 Item de Pedido é de 1 Produto
         */
        modelBuilder.Entity<Produto>()
            .HasMany(p => p.Itens)
            .WithOne(i => i.Produto)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * 1 Pedido tem * Item de Pedido
         * 1 Item de Pedido é de 1 Pedido
         */
        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.Itens)
            .WithOne(ip => ip.Pedido)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Tabela de associação entre Pedido e Produto
         */
        modelBuilder.Entity<ItemPedido>()
            .HasKey(ip => new { ip.PedidoId, ip.ProdutoId });

        /*
         * 1 Pedido tem 1 Pagamento
         * 1 Pagamento é de 1 Pedido
         */
        modelBuilder.Entity<Pagamento>().HasKey(pa => pa.PedidoId);

        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Pagamento)
            .WithOne(pa => pa.Pedido)
            .HasForeignKey<Pagamento>(p => p.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Separando tabela por tipo da subclasse
         */
        modelBuilder.Entity<Pagamento>()
            .UseTptMappingStrategy();
        // .UseTptMappingStrategy().HasKey(p => p.PedidoId);
        modelBuilder.Entity<PagamentoComCartao>()
            .UseTptMappingStrategy();
        // .UseTptMappingStrategy().HasKey(p => p.PedidoId);
        modelBuilder.Entity<PagamentoComBoleto>()
            .UseTptMappingStrategy();
        // .UseTptMappingStrategy().HasKey(p => p.PedidoId);

        /*
         * 1 Pedido tem um Cliente
         * 1 Cliente é de 1 ou * Pedidos
         */
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Associação Unidirecional
         * 1 Pedido tem um EnderecoEntrega
         * 1 Endereco é de 1 Pedido
         */
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.EnderecoEntrega)
            .WithOne()
            .HasForeignKey<Pedido>(p => p.EnderecoEntregaId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * 1 Cliente tem 1 ou * Pedidos
         * 1 Pedido é de 1 Cliente
         */
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Pedidos)
            .WithOne(e => e.Cliente)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * 1 Cliente tem 1 ou * Enderecos
         * 1 Endereco é de 1 Cliente
         */
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Enderecos)
            .WithOne(e => e.Cliente)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Entidade Fraca
         * Associação Unidirecional
         * O Ef Core gerencia a chave primária de uma entidade fraca,
         * criando como chave primária a mesma da tabela proprietária
         * 1 Cliente tem 1 ou * Telefones
         */
        modelBuilder.Entity<Cliente>()
            .OwnsMany(c => c.Telefones, telefone =>
            {
                telefone.ToTable("telefone");
                telefone.WithOwner().HasForeignKey("ClientId");
                telefone.Property<int>("ClientId");
                telefone.HasKey("ClientId");
            });

        /*
         * Associação Unidirecional
         * 1 Endereco tem 1 Cidade
         */
        modelBuilder.Entity<Endereco>()
            .HasOne(e => e.Cidade)
            .WithOne()
            .HasForeignKey<Endereco>(e => e.CidadeId)
            .OnDelete(DeleteBehavior.Restrict);
        /*
         * 1 Cidade tem 1 Estado
         * 1 Estado pode ter 1 ou * Cidades
         */
        modelBuilder.Entity<Cidade>()
            .HasOne(c => c.Estado)
            .WithMany(e => e.Cidades)
            .OnDelete(DeleteBehavior.Restrict);
    }
}