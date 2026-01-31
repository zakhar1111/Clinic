using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration
    : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.PaidAt)
            .IsRequired();

        builder.HasOne(p => p.Appointment)
            .WithMany(a => a.Payments)
            .HasForeignKey(p => p.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.PayType)
            .WithMany()
            .HasForeignKey(p => p.PayTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PayStatus)
            .WithMany()
            .HasForeignKey(p => p.PayStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
