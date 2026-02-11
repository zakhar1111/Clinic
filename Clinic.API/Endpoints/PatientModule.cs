using Carter;
using Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Endpoints;

public class PatientModule
    : CarterModule
{
    public PatientModule() : base("") 
    { }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        /// api / v1 / patients /{ patientId}/ appointments
        app.MapPost(
    "/patients/{patientId}/appointments",
    async (
        int patientId,
        [FromBody] BookinfAppointmentCommand command,
        [FromServices] OperationExecutor mediator,
        CancellationToken ct) =>
    {
        // enforce route value
        command.PatientId = patientId;

        var appointmentId = await mediator
            .ExecuteAsync<BookinfAppointmentCommand,int>(command, ct);

        return Results.Created(
            $"/appointments/{appointmentId}",
            new { appointmentId });
    })
    .WithTags("Patients")
    .WithName("BookAppointment")
    .Produces<int>(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status400BadRequest);
    }
}
