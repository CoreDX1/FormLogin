using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Persistences.Context;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Infrastructure.Persistences.Repositories;

namespace POS.Infrastructure.Extensions;

// configurar la conexion
/// <summary>
/// Extension method for configuring the database connection
/// </summary>
public static class InjectionExtensions
{
    /// <summary>
    /// Adds the FormContext to the service collection and configures it to use SQL Server with a specified connection string.
    /// Also specifies the assembly containing the migrations.
    /// </summary>
    /// <param name="service">The service collection to add the FormContext to</param>
    /// <param name="configuration">The configuration object containing the connection string</param>
    /// <returns>The updated service collection</returns>
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
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        return service;
    }
}
