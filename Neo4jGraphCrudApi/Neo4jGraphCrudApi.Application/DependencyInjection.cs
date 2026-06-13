using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Neo4jGraphCrudApi.Application.Interfaces;
using Neo4jGraphCrudApi.Application.Services;

namespace Neo4jGraphCrudApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IPersonService, PersonService>();

        return services;
    }
}
