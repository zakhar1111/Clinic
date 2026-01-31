using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class DoctorSpecialityConfiguration
    : IEntityTypeConfiguration<DoctorSpeciality>
{
    public void Configure(EntityTypeBuilder<DoctorSpeciality> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.DoctorId).IsRequired();
        builder.Property(x => x.SpecialityId).IsRequired();

        builder.HasOne<Doctor>()
            .WithMany(d => d.Specialities)
            .HasForeignKey(ds => ds.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Speciality>()
            .WithMany()
            .HasForeignKey(ds => ds.SpecialityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
