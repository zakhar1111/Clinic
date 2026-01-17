namespace Clinic.Domain.Entities;

public class Prescription
{
    public int Id { get; set; }
    public string Medicine { get; set; }
    public string Dosage { get; set; }
    public string Frequency { get; set; }
    public string Note { get; set; }
}
