using Clinic.Shared.Events;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Shared.Infrastructure;

public class SharedDbContext(DbContextOptions<SharedDbContext> options)
    : DbContext(options)
{
    public DbSet<IntegrationEvent> IntegrationEvents => Set<IntegrationEvent>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SharedDbContext).Assembly);
        modelBuilder.HasDefaultSchema("shared");
    }
}
