namespace Clinic.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime OnDate { get; set; }
    public int Slot15Min { get; set; }
    public string Reason { get; set; } = string.Empty;
    public int BookingStatusId { get; set; }

    //public Booking Create(
    //    DateTime date,
    //    int slot,
    //    string reason,
    //    int bookingStatusId,
    //    int patient,
    //    int doctor)
    //{
    //    return new Booking 
    //        { 
    //            PatientId = patient,
    //            DoctorId = doctor,
    //            OnDate = date,
    //            Slot15Min = slot,
    //            Reason = reason,
    //            BookingStatusId = bookingStatusId
    //        };
    //}
}
