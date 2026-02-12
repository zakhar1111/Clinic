using Carter;
using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;
using Clinic.Application.Features.Patient.Commands.AttachInsuranceCommand;
using Clinic.Shared.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Endpoints;

public class AppointmentModule
    : CarterModule
{
    public AppointmentModule() : base("")
    {}

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        /// /appointments /{ id}/ payments
        app.MapPost(
            "/appointments/{appointmentId}/payments",
            async (
                int appointmentId,
                [FromBody] PayForAppointmentCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct) =>
            { 
                command.AppointmentId = appointmentId;

                var paymentId = await mediator
                    .ExecuteAsync<PayForAppointmentCommand, int>(command, ct);
                return Results.Created(
                    $"/appointments/{appointmentId}/payments/{paymentId}",
                    new { paymentId}
                    );

            })
            .WithTags("Appointments")
            .WithName("PayAppointment")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        /// /appointments/{id}/insurance
        app.MapPost(
            "/appointments/{id}/insurance",
            async (
                int appointmentId,
                [FromBody] AttachInsuranceCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct) =>
            {
                command.AppointmentId = appointmentId;

                var insuranceId = await mediator
                    .ExecuteAsync<AttachInsuranceCommand, int>(command, ct);

                return Results.Created(
                    $"/appointments/{appointmentId}/insurance/{insuranceId}",
                    new { insuranceId }
                    );
            })
            .WithTags("Appointment")
            .WithName("AttachInsurance")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        /// /appointments/{id}/diagnostics
        /// /appointments/{id}/notes
        /// /appointments /{ id}/ prescriptions
        /// 

    }
}
