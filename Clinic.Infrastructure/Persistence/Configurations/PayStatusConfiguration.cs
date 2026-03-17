using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class PayStatusConfiguration
    : IEntityTypeConfiguration<PayStatus>
{
    public void Configure(EntityTypeBuilder<PayStatus> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

        builder.HasData(
            PayStatus.Seed(1, "Created") ,
            PayStatus.Seed(2, "Authorized" ),
            PayStatus.Seed(3, "Paid" ),
            PayStatus.Seed(4, "Failed" ),
            PayStatus.Seed(5, "Refunded")
        );
    }
}


