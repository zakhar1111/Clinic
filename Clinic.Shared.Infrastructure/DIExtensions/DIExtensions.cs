using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Shared.Infrastructure.DIExtensions;

public static class DIExtensions
{
    public static void ApplySharedMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using SharedDbContext context = scope.ServiceProvider.GetService<SharedDbContext>();
        context.Database.Migrate();
    }
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
