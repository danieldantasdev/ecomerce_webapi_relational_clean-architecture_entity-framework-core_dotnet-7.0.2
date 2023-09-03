using Microsoft.EntityFrameworkCore;
using VirtualStore.Core.Entities;
using VirtualStore.Core.Enums;
using VirtualStore.Core.Interfaces.Repositories;
using VirtualStore.Infrastructure.Implementations.Repositories;
using VirtualStore.Infrastructure.Persisntences.Context;

namespace VirtualStore.Api.Extensions;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructureExtension(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddDatabaseExtension(configuration);
    }


    private static IServiceCollection AddDatabaseExtension(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("VirtualStoreConnectionString");
        serviceCollection.AddDbContext<VirtualStoreDbContext>(options => options.UseSqlServer(connectionString));
        return serviceCollection;
    }

    private static IServiceCollection AddDependencyInjectionExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        return serviceCollection;
    }
}