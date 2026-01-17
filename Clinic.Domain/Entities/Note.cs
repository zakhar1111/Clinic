namespace Clinic.Domain.Entities;

public class Note
{
    public int Id { get; set; }
    public int PrescriptionId { get; set; }
    public int CteatedAt { get; set; }
    public int DiagnosticId { get; set; }
}
