
namespace Clinic.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public decimal Price { get; set; }
    public string Currency { get; set; }

    public int BookingId { get; set; }
    public int AppointmentStatusId { get; set; }
    public int? InsuranceId { get; set; }

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

        if (booking.BookingStatusId !=  (int) BookingStatusEnum.Scheduled)// 1)    // [TODO] - clarify Confirmed
            throw new InvalidOperationException(
                "Appointment can only be created from a scheduled/confirmed booking.");

        booking.Confirm(); 

        return new Appointment
        {
            BookingId = booking.Id,
            Booking = booking,
            AppointmentStatusId = (int)AppointmentStatusEnum.Scheduled, 
            InsuranceId = insurance?.Id,
            Insurance = insurance,
            Price = price,
            Currency = currency
        };
    }

    public Note AddNote(string content)
    {
        this.EnsureNotCanceled();
        
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
        this.EnsureInProgress();
        
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
        if (AppointmentStatusId == (int)AppointmentStatusEnum.Scheduled) // if Scheduled set InProgress to allow adding diagnostics for in progress appointments only
            Start();

        if (string.IsNullOrWhiteSpace(testName))
            throw new ArgumentException(
                "Test name cannot be empty", nameof(testName));

        if (string.IsNullOrWhiteSpace(results))
            throw new ArgumentException(
                "Test results cannot be empty", nameof(results));

        EnsureInProgress();

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

    public Payment AddPayment(decimal amount, int payMethod)
    {
        EnsureInProgress();

        if (amount <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(amount), "Payment amount must be positive.");

        var payment = new Payment
        {
            Amount = amount,
            PayTypeId = payMethod,
            PayStatusId = 1, // Created
            PaidAt = DateTime.UtcNow,
            AppointmentId = this.Id,
            Appointment = this
        };

        Payments.Add(payment);

        return payment;
    }
    public void Start() 
    {
        EnsureStatus(AppointmentStatusEnum.Scheduled);
        Booking.Confirm();
        AppointmentStatusId = (int)AppointmentStatusEnum.InProgress;
    }
    public void MarkAsCompleted()
    {
        EnsureStatus(AppointmentStatusEnum.InProgress);
        Booking.Complete();
        AppointmentStatusId = (int)AppointmentStatusEnum.Completed;
    }

    public void Cancel()
    {
        if(AppointmentStatusId == (int)AppointmentStatusEnum.Completed)
            throw new InvalidOperationException("Completed appointment cannot be canceled.");
        if(AppointmentStatusId == (int)AppointmentStatusEnum.Cancelled)
            throw new InvalidOperationException("Appointment is already canceled.");    

        Booking.Canceled();
        AppointmentStatusId = (int)AppointmentStatusEnum.Cancelled;
    }

    public Insurance ApplyInsurance(string provider, int coverage)
    {
        this.EnsureNotCanceled();

        Insurance = Insurance.Create(provider, coverage);
        InsuranceId = Insurance.Id;
        return Insurance;
    }

    public decimal CalculateTotalPayments() =>
        Payments.Sum(p => p.Amount);
    public bool IsFullyPaid() =>
        CalculateTotalPayments() >= Price;

    private void EnsureInProgress()
    {
        if (AppointmentStatusId != (int)AppointmentStatusEnum.InProgress)
        {
            throw new InvalidOperationException(
                "Operation allowed only when appointment is active = InProgress.");
        }
    }
    private void EnsureNotCanceled()
    {
        if (AppointmentStatusId == (int)AppointmentStatusEnum.Cancelled)
            throw new InvalidOperationException(
                "Operation not allowed for cancelled appointments.");
    }

    private void EnsureStatus(AppointmentStatusEnum expected)
    { 
        if(AppointmentStatusId != (int) expected)
            throw new InvalidOperationException(
                $"Operation allowed only when appointment is in {expected} status.");
    }
}
