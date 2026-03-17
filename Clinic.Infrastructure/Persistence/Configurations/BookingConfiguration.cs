using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class BookingConfiguration
    : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OnDate)
            .IsRequired();

        builder.Property(b => b.BookingStatusId).IsRequired();

        builder.Property(b => b.DurationIn15MinSlots)
            .IsRequired();

        builder.HasOne<Patient>()
            .WithMany(p => p.Bookings)
            .HasForeignKey(b => b.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<BookingStatus>()
            .WithMany()
            .HasForeignKey(b => b.BookingStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
