using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Persistences.Context;

namespace POS.Infrastructure.Extensions;

// configurar la conexion
public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(
        this IServiceCollection service,
        IConfiguration configuration
    )
    {
        var assembly = typeof(FormContext).Assembly.FullName;
        service.AddDbContext<FormContext>(
            options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("POSConnectionString"),
                    b => b.MigrationsAssembly(assembly)
                ),
            ServiceLifetime.Transient
        );
        return service;
    }
}
