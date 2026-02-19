using Microsoft.EntityFrameworkCore;

namespace Clinic.Shared.Infrastructure;

public class SharedDbContext(DbContextOptions<SharedDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("shared");
    }
}
