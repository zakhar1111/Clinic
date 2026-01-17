namespace Clinic.Domain.Entities;

public class Payment
{ 
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int PayTypeId { get; set; }
    public int PayStatusId { get; set; }
    public double Amount { get; set; }
    public DateTime OnDate { get; set; }
}
