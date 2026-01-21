using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration
    : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(a => a.Currency).IsRequired().HasMaxLength(3);
        builder.Property(a => a.BookingId).IsRequired();

        builder.HasOne(a => a.Booking)
            .WithMany()
            .HasForeignKey(a => a.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.AppointmentStatus)
            .WithMany()
            .HasForeignKey(a => a.AppointmentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Insurance)
            .WithMany()
            .HasForeignKey(a => a.InsuranceId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}

public class DiagnosticConfiguration
    : IEntityTypeConfiguration<Diagnostic>
{
    public void Configure(EntityTypeBuilder<Diagnostic> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.AppointmentId).IsRequired();
        builder.Property(d => d.Name).IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.TestResults)
             .HasMaxLength(500);

        builder.HasOne(d => d.Appointment)
            .WithMany(a => a.Diagnostics)
            .HasForeignKey(d => d.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class PrescriptionConfiguration
    : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.AppointmentId)
            .IsRequired();

        builder.Property(p => p.Medicine)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Dosage)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Frequency)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CreatedAt).IsRequired();

        builder.HasOne(p => p.Appointment)
            .WithMany(a => a.Prescriptions)
            .HasForeignKey(p => p.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class NoteConfiguration
    : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(n => n.Id);
        
        builder.Property(n => n.CreatedAt).IsRequired();
        builder.Property(n => n.Text).HasMaxLength(1000);

        builder.Property(n => n.AppointmentId).IsRequired();

        builder.HasOne(n => n.Appointment)
            .WithMany(a => a.Notes)
            .HasForeignKey(n => n.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class InsuranceConfiguration
    : IEntityTypeConfiguration<Insurance>
{
    public void Configure(EntityTypeBuilder<Insurance> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Provider)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(i => i.Coverage)
            .IsRequired();
    }
}
public class AppointmentStatusConfiguration
    : IEntityTypeConfiguration<AppointmentStatus>
{
    public void Configure(EntityTypeBuilder<AppointmentStatus> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
