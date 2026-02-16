using Carter;
using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;
using Clinic.Application.Features.Doctor.Commands.AddDiagnosticCommand;
using Clinic.Application.Features.Doctor.Commands.AddNoteCommand;
using Clinic.Application.Features.Doctor.Commands.AddPrescriptionCommand;
using Clinic.Application.Features.Patient.Commands.AttachInsuranceCommand;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            .WithTags("Appointment")
            .WithName("PayAppointment")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        /// /appointments/{id}/insurance
        app.MapPost(
            "/appointments/{appointmentId}/insurance",
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
        app.MapPost(
            "/appointments/{appointmentId}/diagnostics",
            async(
                int appointmentId,
                [FromBody] AddDiagnosticCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct) =>
            {
                command.AppointmentId = appointmentId;

                var diagnosticId = await mediator
                    .ExecuteAsync< AddDiagnosticCommand, int>(command, ct);

                return Results.Created(
                    $"/appointments/{appointmentId}/insurance/{diagnosticId}",
                    new { diagnosticId });
            })
            .WithTags("Appointment")
            .WithName("AttachDiagnostic")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        
        /// /appointments/{id}/notes
        app.MapPost(
            "/appointments/{appointmentId}/notes",
            async (
                int appointmentId,
                [FromBody] AddNoteCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct) =>
            {
                command.AppointmentId = appointmentId;
                var noteId = await mediator
                    .ExecuteAsync<AddNoteCommand, int>(command, ct);
                return Results.Created(
                    $"/appointments/{appointmentId}/notes/{noteId}",
                    new { noteId });
            })
            .WithTags("Appointment")
            .WithName("AddNote")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        /// /appointments /{ id}/ prescriptions
        app.MapPost(
            "/appointments/{appointmentId}/prescriptions",
            async (
                int appointmentId,
                [FromBody] AddPrescriptionCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct) =>
            {
                command.AppointmentId = appointmentId;
                var prescriptionId = await mediator
                    .ExecuteAsync<AddPrescriptionCommand, int>(command, ct);
                return Results.Created(
                    $"/appointments/{appointmentId}/prescriptions/{prescriptionId}",
                    new { prescriptionId });
            })
            .WithTags("Appointment")
            .WithName("AddPrescription")
            .Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

    }
}
