using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;

public class PayForAppointmentCommand
    : IRequest<int>
{
    public int AppointmentId { get; set; }
    public decimal Amount { get; set; }
    public int PayTypeId { get; set; }

}

public record PayTypeDto(int Id, string Name);
