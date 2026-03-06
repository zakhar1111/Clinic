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
            new Speciality { Id = 1, Name = "Cardiology" },
            new Speciality { Id = 2, Name = "Dermatology" },
            new Speciality { Id = 3, Name = "Neurology" },
            new Speciality { Id = 4, Name = "Pediatrics" },
            new Speciality { Id = 5, Name = "Psychiatry" },
            new Speciality { Id = 6, Name = "Family Doctor" }
        );
    }
}
