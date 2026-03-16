using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class PayTypeConfiguration
    : IEntityTypeConfiguration<PayType>
{
    public void Configure(EntityTypeBuilder<PayType> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            PayType.Seed(1,"Cash"),
            PayType.Seed(2,"Credit Card"),
            PayType.Seed(3,"Insurance")
            );
    }
}
