using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Clinic.Shared.Events;

namespace Clinic.Shared.Infrastructure.Configurations;

public class IntegrationEventConfiguration 
    : IEntityTypeConfiguration<IntegrationEvent>
{
    public void Configure(EntityTypeBuilder<IntegrationEvent> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Type).IsRequired();
        builder.Property(e => e.Payload).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.Processed).IsRequired();
    }
}
