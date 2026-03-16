using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class SpecialityConfiguration
    : IEntityTypeConfiguration<Speciality>
{
    public void Configure(EntityTypeBuilder<Speciality> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            Speciality.Seed(1, "Cardiology"),
            Speciality.Seed(2, "Dermatology"),
            Speciality.Seed(3, "Neurology"),
            Speciality.Seed(4, "Pediatrics"),
            Speciality.Seed(5, "Psychiatry"),
            Speciality.Seed(6, "Family Doctor")
        );
    }
}
