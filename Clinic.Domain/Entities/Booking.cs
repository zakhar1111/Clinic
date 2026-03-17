namespace Clinic.Domain.Entities;

public class Booking
{
    public int Id { get; private set; }
    public int PatientId { get; private set; }
    public int DoctorId { get; private set; }
    public DateTime OnDate { get; private set; }
    public int DurationIn15MinSlots { get; private set; }  // longevity in slots of 15 minutes for the booking
    public string Reason { get; private set; }
    public int BookingStatusId { get; private set; }

    private Booking() { } // for EF Core

    public static Booking Create(
        int patientId, 
        int doctorId, 
        DateTime date, 
        int slotsNumber, 
        string reason)
    {
        if (patientId <= 0)
            throw new ArgumentException("Invalid patientId");

        if (doctorId <= 0)
            throw new ArgumentException("Invalid doctorId");

        if (slotsNumber <= 0)
            throw new ArgumentException("Duration must be positive");

        if (string.IsNullOrWhiteSpace(reason))
            throw new ArgumentException("Reason required");

        var newBooking = new Booking
        {
            OnDate = date,
            DoctorId = doctorId,
            PatientId = patientId,
            DurationIn15MinSlots = slotsNumber,
            BookingStatusId = (int) BookingStatusEnum.Scheduled  //1 // Scheduled
        };
        return newBooking;
    }

    public void Confirm()
    {
        EnsureStatus(BookingStatusEnum.Scheduled);
        BookingStatusId = (int) BookingStatusEnum.Confirmed;
    }

    public void Complete()
    {
        EnsureStatus(BookingStatusEnum.Confirmed);
        BookingStatusId = (int) BookingStatusEnum.Completed;
    }
    public void Canceled()
    { 
        if(BookingStatusId == (int) BookingStatusEnum.Completed)
            throw new InvalidOperationException("Completed booking cannot be canceled.");
        if (BookingStatusId == (int) BookingStatusEnum.Cancelled)
            throw new InvalidOperationException("Booking is already canceled.");
        
        BookingStatusId = (int) BookingStatusEnum.Cancelled; 
    }

    private void EnsureStatus(BookingStatusEnum expected)
    {
        if (BookingStatusId != (int) expected)
            throw new InvalidOperationException(
                $"Operation allowed only when Booking is in {expected} status.");
    }

    
}
