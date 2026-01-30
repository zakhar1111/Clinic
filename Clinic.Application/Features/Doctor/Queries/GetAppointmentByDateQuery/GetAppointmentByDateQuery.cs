using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Doctor.Queries.GetAppointmentByDateQuery;

public class GetAppointmentByDateQuery
    : IRequest<List<AppointmentSummaryDto>>
{
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
}

public class AppointmentSummaryDto
{
    public int AppointmentId { get; set; }
    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    public string Status { get; set; }
}