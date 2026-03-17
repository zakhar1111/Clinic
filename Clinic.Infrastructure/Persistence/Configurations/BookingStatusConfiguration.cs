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
            BookingStatus.Seed(1, "Scheduled"),
            BookingStatus.Seed(2, "Confirmed"),
            BookingStatus.Seed(3, "Canceled"),
            BookingStatus.Seed(4, "Completed")  
        );
    }
}
