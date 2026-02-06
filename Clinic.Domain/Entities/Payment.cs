namespace Clinic.Domain.Entities;

public class Payment
{
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime PaidAt { get; set; }

    public int AppointmentId { get; set; }
    public int PayTypeId { get; set; }
    public int PayStatusId { get; set; }

    public Appointment Appointment { get; set; }
    public PayType PayType { get; set; }
    public PayStatus PayStatus { get; set; }


}
