using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scriptura.Domain.Repositories;
using Scriptura.Infrastructure.Postgres;
using Scriptura.Infrastructure.Postgres.Repositories;

namespace Scriptura.Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ScripturaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));

        services.AddScoped<IArchivalItemRepository, ArchivalItemRepository>();
        services.AddScoped<ISettlementRepository, SettlementRepository>();

        return services;
    }
}