
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
        string currency,
        Insurance? insurance = null
        )
    {
        if (booking == null)
            throw new ArgumentNullException(nameof(booking));

        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price));

        if (booking.BookingStatusId !=  2) // Confirmed
            throw new InvalidOperationException(
                "Appointment can only be created from a confirmed booking.");

        return new Appointment
        { 
            Booking = booking,
            AppointmentStatusId = 1, // Scheduled
            AppointmentStatus = new AppointmentStatus
            {
                Id = 1, // Scheduled
            },
            InsuranceId = insurance?.Id,
            Insurance = insurance,
            Price = price,
            Currency = currency
        };
    }

    public Note AddNote(string content)
    {
        if (this.AppointmentStatusId == 3) // Cancelled
            throw new InvalidOperationException(
                "Cannot add notes to a cancelled appointment");

        var newNote = new Note
        {
            Text = content,
            CreatedAt = DateTime.UtcNow,
            AppointmentId = this.Id,
            Appointment = this
        };

        Notes.Add(newNote);
        return newNote;
    }

    public Prescription AddPrescription(
        string medicine, 
        string dosage, 
        string frequency)
    {
        if(this.AppointmentStatusId == 3) // Cancelled
            throw new InvalidOperationException(
                "Cannot add prescriptions to a cancelled appointment");

        if(string.IsNullOrWhiteSpace(medicine))
            throw new ArgumentException(
                "Medicine name cannot be empty", nameof(medicine));
        if (string.IsNullOrWhiteSpace(dosage))
            throw new ArgumentException(
                "Dosage cannot be empty", nameof(dosage));
        if (string.IsNullOrWhiteSpace(frequency))
            throw new ArgumentException(
                "Frequency cannot be empty", nameof(frequency));

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

    public Diagnostic AddDiagnostic(string testName, string results)
    {
        if (this.AppointmentStatusId == 3) // Cancelled
            throw new InvalidOperationException(
                "Cannot add diagnostic to a cancelled appointment");
        if (string.IsNullOrWhiteSpace(testName))
            throw new ArgumentException(
                "Test name cannot be empty", nameof(testName));

        if (string.IsNullOrWhiteSpace(results))
            throw new ArgumentException(
                "Test results cannot be empty", nameof(results));

        var newDiagnostic = new Diagnostic
        {
            Name = testName,
            TestResults = results,
            AppointmentId = this.Id,
            Appointment = this
        };
        Diagnostics.Add(newDiagnostic);
        return newDiagnostic;
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

    public Insurance ApplyInsurance(string provider, int coverage)
    {
        if(AppointmentStatusId != 1) // Scheduled
            throw new InvalidOperationException(
                "Insurance can only be attached to scheduled appointments.");

        Insurance = Insurance.Create(provider, coverage);
        InsuranceId = Insurance.Id;
        return Insurance;
    }

    public decimal CalculateTotalPayments()
    {
        return Payments.Sum(p => p.Amount);
    }

}
