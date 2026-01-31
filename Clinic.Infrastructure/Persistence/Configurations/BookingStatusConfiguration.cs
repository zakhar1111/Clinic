using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class BookingStatusConfiguration
    : IEntityTypeConfiguration<BookingStatus>
{
    public void Configure(EntityTypeBuilder<BookingStatus> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new BookingStatus { Id = 1, Name = "Scheduled" },
            new BookingStatus { Id = 2, Name = "Confirmed" },
            new BookingStatus { Id = 3, Name = "Canceled" },
            new BookingStatus { Id = 4, Name = "Completed" }
        );
    }
}
