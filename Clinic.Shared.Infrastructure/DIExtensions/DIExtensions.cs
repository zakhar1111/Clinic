using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Shared.Infrastructure.DIExtensions;

public static class DIExtensions
{
    public static IServiceCollection AddSharedInfrastructure(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddDbContext<SharedDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("Default"),
                sql =>
                {
                    sql.MigrationsHistoryTable("__EFMigrationsHistory", "shared");
                    sql.MigrationsAssembly("Clinic.Shared.Infrastructure");
                }
            )
        );
        return services;
    }
}
