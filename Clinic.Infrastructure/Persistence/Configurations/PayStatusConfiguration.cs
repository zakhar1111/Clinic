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
            new PayStatus { Id = 1, Name = "Paid" },
            new PayStatus { Id = 2, Name = "Unpaid" },
            new PayStatus { Id = 3, Name = "Pending" }
        );
    }
}
