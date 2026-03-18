using Clinic.Domain.Entities;
using Clinic.Infrastructure.Persistence.Convertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class PatientConfiguration
    : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UserId)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Email)
            .HasConversion<EmailConverter>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Phone)
            .HasConversion<PhoneConverter>()
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(p => p.GovId)
            .HasConversion<GovIdConverter>()
            .IsRequired()
            .HasMaxLength(20);
    }
}
