
namespace Clinic.Domain.Entities;

public class Appointment
{
    public int Id { get; private  set; }

    public decimal Price { get; private set; }
    public string Currency { get; private  set; }

    public int BookingId { get; private set; }
    public int AppointmentStatusId { get; private set; }
    public int? InsuranceId { get; private set; }

    public Booking Booking { get; private set; }
    public Insurance? Insurance { get; private set; }
    public IReadOnlyCollection<Note> Notes => notes;
    public IReadOnlyCollection<Prescription> Prescriptions => prescriptions;
    public IReadOnlyCollection<Diagnostic> Diagnostics  => diagnostics;
    public IReadOnlyCollection<Payment> Payments => payments;


    private readonly List<Note> notes = new();
    private readonly List<Prescription> prescriptions = new();
    private readonly List<Diagnostic> diagnostics = new();
    private readonly List<Payment> payments = new();

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

        if (booking.BookingStatusId !=  (int) BookingStatusEnum.Scheduled)  
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
        if(AppointmentStatusId != (int)AppointmentStatusEnum.InProgress)
            throw new InvalidOperationException("Notes can only be added to appointments that are in progress.");

        var newNote = Note.Create(content, this);
        notes.Add(newNote);

        return newNote;
    }

    public Prescription AddPrescription(
        string medicine, 
        string dosage, 
        string frequency)
    {
        if(AppointmentStatusId != (int)AppointmentStatusEnum.InProgress)
            throw new InvalidOperationException("Prescriptions can only be added to appointments that are in progress.");

        var prescription = Prescription.Create(medicine, dosage, frequency, this);
        prescriptions.Add(prescription);

        return prescription;
    }
    
    public Diagnostic AddDiagnostic(string testName, string results)
    {
        if(AppointmentStatusId != (int)AppointmentStatusEnum.InProgress)
            throw new InvalidOperationException("Diagnostics can only be added to appointments that are in progress.");

        var newDiagnostic = Diagnostic.Create(testName, results, this);
        diagnostics.Add(newDiagnostic);

        return newDiagnostic;
    }

    public Payment AddPayment(decimal amount, PayType payType)
    {
        if(AppointmentStatusId != (int)AppointmentStatusEnum.InProgress)
            throw new InvalidOperationException("Payments can only be added to appointments that are in progress.");

        var payment = Payment.Create(amount, payType, this);
        payments.Add(payment);

        return payment;
    }
    public void Start() 
    {
        if(AppointmentStatusId != (int)AppointmentStatusEnum.Scheduled)
            throw new InvalidOperationException("Only scheduled appointment can be started.");
        
        AppointmentStatusId = (int)AppointmentStatusEnum.InProgress;
    }
    public void MarkAsCompleted()
    {
        if(AppointmentStatusId != (int)AppointmentStatusEnum.InProgress)
            throw new InvalidOperationException("Only in progress appointment can be completed.");

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
        if(AppointmentStatusId == (int)AppointmentStatusEnum.Cancelled)
            throw new InvalidOperationException("Cannot apply insurance to a cancelled appointment.");

        Insurance = Insurance.Create(provider, coverage);
        InsuranceId = Insurance.Id;

        return Insurance;
    }

    public decimal CalculateTotalPayments() =>
        Payments.Sum(p => p.Amount);
    public bool IsFullyPaid() =>
        CalculateTotalPayments() >= Price;
}
