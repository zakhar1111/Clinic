using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;

public class BookinfAppointmentCommand
    : IRequest<int>
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime OnDate { get; set; }
    public int DurationInSlots { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
}
