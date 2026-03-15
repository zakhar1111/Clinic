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
            Speciality.Create("Cardiology"),
            Speciality.Create("Dermatology"),
            Speciality.Create("Neurology"),
            Speciality.Create("Pediatrics"),
            Speciality.Create("Psychiatry"),
            Speciality.Create("Family Doctor")
        );
    }
}
