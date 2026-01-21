using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class ShiftConfiguration
    : IEntityTypeConfiguration<Shift>
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.DoctorId).IsRequired();
        builder.Property(s => s.StartTime).IsRequired();
        builder.Property(s => s.Slot15Min).IsRequired();

    }
}
