using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class DoctorConfiguration
    : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(50);  

        builder.Property(d => d.Phone)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(d => d.Bio)
            .HasMaxLength(500);

        builder.HasMany(d => d.Bookings)
            .WithOne()
            .HasForeignKey(b => b.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Specialities)
            .WithOne()
            .HasForeignKey(ds => ds.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Shifts)
            .WithOne()
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
