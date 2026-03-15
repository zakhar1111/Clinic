
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
        EnsureNotCanceled();
        
        var newNote = Note.Create(content, this);
        notes.Add(newNote);

        return newNote;
    }

    public Prescription AddPrescription(
        string medicine, 
        string dosage, 
        string frequency)
    {
        this.EnsureInProgress();

        var prescription = Prescription.Create(medicine, dosage, frequency, this);
        prescriptions.Add(prescription);

        return prescription;
    }
    
    public Diagnostic AddDiagnostic(string testName, string results)
    {
        EnsureStatus(AppointmentStatusEnum.InProgress);
        var newDiagnostic = Diagnostic.Create(testName, results, this);
        diagnostics.Add(newDiagnostic);
        return newDiagnostic;
    }

    public Payment AddPayment(decimal amount, PayType payType)//int payMethod)
    {
        EnsureInProgress();

        var payment = Payment.Create(amount, payType, this);

        payments.Add(payment);

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
