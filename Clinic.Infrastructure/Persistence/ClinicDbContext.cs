using Microsoft.EntityFrameworkCore;

namespace Clinic.Infrastructure.Persistence;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
        modelBuilder.HasDefaultSchema("clinic");
    }
}
