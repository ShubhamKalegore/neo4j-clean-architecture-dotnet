using Neo4jGraphCrudApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neo4j.Driver;
using Neo4jGraphCrudApi.Application.Interfaces;
using Neo4jGraphCrudApi.Infrastructure.Repositories;

namespace Neo4jGraphCrudApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));

        services.AddSingleton<IDriver>(_ =>
        {
            return GraphDatabase.Driver(
                configuration["Neo4j:Uri"],
                AuthTokens.Basic(
                    configuration["Neo4j:Username"],
                    configuration["Neo4j:Password"]));
        });
        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }
}
