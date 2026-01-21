using Clinic.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Infrastructure.Extensions;

public static class DIExtensions
{
    public static void ApplyClinicMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using ClinicDbContext context = scope.ServiceProvider.GetService<ClinicDbContext>();
        context.Database.Migrate();
    }
    public static IServiceCollection AddClinicInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("Default"),
                sql =>
                {
                    sql.MigrationsHistoryTable("__EFMigrationsHistory", "deeds.message");
                    sql.MigrationsAssembly("Clinic.Infrastructure");
                }
                )
            );

        return services;
    }
}
