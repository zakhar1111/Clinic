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

        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

        builder.HasData(
            new PayType { Id = 1, Name = "Cash" },
            new PayType { Id = 2, Name = "Credit Card" },
            new PayType { Id = 3, Name = "Insurance" }
            );
    }
}
