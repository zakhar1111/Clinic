namespace Clinic.Application.Services;

public interface IDoctorAvailabilityService
{
    Task EnsureAvailabilityAsync(
        int doctorId,
        DateTime date,
        int requiredSlots,
        CancellationToken ct);
}
