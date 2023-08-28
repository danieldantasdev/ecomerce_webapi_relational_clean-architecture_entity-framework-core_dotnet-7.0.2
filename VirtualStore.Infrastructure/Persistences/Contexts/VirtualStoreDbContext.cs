using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VirtualStore.Core.Entities;
using VirtualStore.Core.Enums;

namespace VirtualStore.Infrastructure.Persisntences.Context;

public class VirtualStoreDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Address> Adresses { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentWithSlip> PaymentWithSlips { get; set; }
    public DbSet<PaymentWithCard> PaymentWithCards { get; set; }

    public VirtualStoreDbContext(DbContextOptions<VirtualStoreDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    void DefineNameTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("category");
        modelBuilder.Entity<Product>().ToTable("product");
        modelBuilder.Entity<Order>().ToTable("order");
        modelBuilder.Entity<OrderItem>().ToTable("order_item");
        modelBuilder.Entity<Payment>().ToTable("payment");
        modelBuilder.Entity<PaymentWithSlip>().ToTable("payment_with_slip");
        modelBuilder.Entity<PaymentWithCard>().ToTable("payment_with_card");
        modelBuilder.Entity<Client>().ToTable("client");
        modelBuilder.Entity<State>().ToTable("state");
        modelBuilder.Entity<City>().ToTable("city");
        modelBuilder.Entity<Address>().ToTable("address");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DefineNameTables(modelBuilder);

        /*
         * 1 Category tem 1 ou * produtos
         * 1 Product é de * Categories
         */
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithMany(p => p.Categories)
            .UsingEntity(j => j.ToTable("category_product"));

        /*
         * 1 Product tem * Item de Order
         * 1 Item de Order é de 1 Product
         */
        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderItens)
            .WithOne(i => i.Product)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * 1 Order tem * Item de Order
         * 1 Item de Order é de 1 Order
         */
        modelBuilder.Entity<Order>()
            .HasMany(p => p.Itens)
            .WithOne(ip => ip.Order)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Tabela de associação entre Order e Product
         */
        modelBuilder.Entity<OrderItem>()
            .HasKey(ip => new { PedidoId = ip.OrderId, ProdutoId = ip.ProductId });

        /*
         * 1 Order tem 1 Payment
         * 1 Payment é de 1 Order
         */
        modelBuilder.Entity<Payment>().HasKey(pa => pa.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(p => p.Payment)
            .WithOne(pa => pa.Order)
            .HasForeignKey<Payment>(p => p.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Separando tabela por tipo da subclasse
         */
        modelBuilder.Entity<Payment>()
            .UseTptMappingStrategy();
        // .UseTptMappingStrategy().HasKey(p => p.OrderId);
        modelBuilder.Entity<PaymentWithCard>()
            .UseTptMappingStrategy();
        // .UseTptMappingStrategy().HasKey(p => p.OrderId);
        modelBuilder.Entity<PaymentWithSlip>()
            .UseTptMappingStrategy();
        // .UseTptMappingStrategy().HasKey(p => p.OrderId);

        /*
         * 1 Order tem um Client
         * 1 Client é de 1 ou * Orders
         */
        modelBuilder.Entity<Order>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Orders)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Associação Unidirecional
         * 1 Order tem um DeliveryAddress
         * 1 Address é de 1 Order
         */
        modelBuilder.Entity<Order>()
            .HasOne(p => p.DeliveryAddress)
            .WithOne()
            .HasForeignKey<Order>(p => p.DeliveryAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * 1 Client tem 1 ou * Orders
         * 1 Order é de 1 Client
         */
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Orders)
            .WithOne(e => e.Client)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * 1 Client tem 1 ou * Adresses
         * 1 Address é de 1 Client
         */
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Adresses)
            .WithOne(e => e.Client)
            .OnDelete(DeleteBehavior.Restrict);

        /*
         * Entidade Fraca
         * Associação Unidirecional
         * O Ef Core gerencia a chave primária de uma entidade fraca,
         * criando como chave primária a mesma da tabela proprietária
         * 1 Client tem 1 ou * Phones
         */
        modelBuilder.Entity<Client>()
            .OwnsMany(c => c.Phones, phone =>
            {
                phone.ToTable("phone");
                phone.WithOwner().HasForeignKey("client_id");
                phone.Property<int>("client_id");
                phone.HasKey("client_id");
            });

        /*
         * Associação Unidirecional
         * 1 Address tem 1 City
         */
        modelBuilder.Entity<Address>()
            .HasOne(e => e.City)
            .WithOne()
            .HasForeignKey<Address>(e => e.CityId)
            .OnDelete(DeleteBehavior.Restrict);
        /*
         * 1 City tem 1 State
         * 1 State pode ter 1 ou * Cities
         */
        modelBuilder.Entity<City>()
            .HasOne(c => c.State)
            .WithMany(e => e.Cities)
            .OnDelete(DeleteBehavior.Restrict);
    }
}