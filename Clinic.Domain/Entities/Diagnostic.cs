namespace Clinic.Domain.Entities;

public class Diagnostic
{
    public int Id { get; private set; }

    public string Name { get; private set; }
    public string TestResults { get; private set; }

    public int AppointmentId { get; private set; }

    public Appointment Appointment { get; private set; }

    private Diagnostic() { }

    public static Diagnostic Create(
        string testName,
        string testResults,
        Appointment appointment)
    {
        if (string.IsNullOrWhiteSpace(testName))
            throw new ArgumentNullException("name cannot be empty");
        if (string.IsNullOrWhiteSpace(testResults))
            throw new ArgumentNullException("testResults cannot be empry");
        if (appointment is null)
            throw new ArgumentNullException("Invalid appointment");

        var diagnostic = new Diagnostic
        {
            Name = testName,
            TestResults = testResults,
            Appointment = appointment,
            AppointmentId = appointment.Id
        };

        return diagnostic;
    }
}