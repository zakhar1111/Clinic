
namespace Clinic.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public decimal Price { get; set; }
    public string Currency { get; set; }

    public int BookingId { get; set; }
    public int AppointmentStatusId { get; set; }
    public int? InsuranceId { get; set; }

    public AppointmentStatus AppointmentStatus { get; set; }
    public Booking Booking { get; set; }
    public Insurance? Insurance { get; set; }
    public List<Note> Notes { get; set; } = new();
    public List<Prescription> Prescriptions { get; set; } = new();
    public List<Diagnostic> Diagnostics { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();

    public static Appointment Create(
        Booking booking, 
        decimal price, 
        Insurance? insurance, 
        string currency
        )
    {
        return new Appointment
        { 
            Booking = booking,
            AppointmentStatusId = 1, // Scheduled
            InsuranceId = insurance?.Id,
            Insurance = insurance,
            Price = price,
            Currency = currency
        };
    }

    public void AddNote(string content)
    {
        if (this.AppointmentStatusId == 3) // Cancelled
            throw new InvalidOperationException(
                "Cannot add notes to a cancelled appointment");

        Notes.Add(new Note
        {
            Text = content,
            CreatedAt = DateTime.UtcNow,
            AppointmentId = this.Id,
            Appointment = this
        });
    }

    public Prescription AddPrescription(
        string medicine, 
        string dosage, 
        string frequency)
    {
        var prescription = new Prescription
        {
            Medicine = medicine,
            Dosage = dosage,
            Frequency = frequency,
            CreatedAt = DateTime.UtcNow,
            AppointmentId = this.Id,
            Appointment = this
        };

        Prescriptions.Add(prescription);
        return prescription;
    }

    public void AddDiagnostic(string testName, string results)
    {
        Diagnostics.Add(new Diagnostic
        {
            Name = testName,
            TestResults = results,
            AppointmentId = this.Id,
            Appointment = this
        });
    }

    public void AddPayment(decimal amount, int payMethod)
    {
        Payments.Add(new Payment
        {
            Amount = amount,
            PayTypeId = payMethod,
            PayStatusId = 1, // Waiting
            PaidAt = DateTime.UtcNow,
            AppointmentId = this.Id,
            Appointment = this
        });
    }
    
    public void MarkAsPaid()
    {
        AppointmentStatusId = 2;// Paid
        AppointmentStatus = new AppointmentStatus { Id = AppointmentStatusId };
    }

    public void MarkAsCompleted()
    {
        AppointmentStatusId = 4;// Completed
        AppointmentStatus = new AppointmentStatus { Id = AppointmentStatusId };
    }

    public void Cancel()
    {
        AppointmentStatusId = 3;// Canceled
        AppointmentStatus = new AppointmentStatus { Id = AppointmentStatusId };
    }

    public void ApplyInsurance(Insurance insurance)
    {
        InsuranceId = insurance.Id;
        Insurance = insurance;
    }

    public decimal CalculateTotalPayments()
    {
        return Payments.Sum(p => p.Amount);
    }

}
