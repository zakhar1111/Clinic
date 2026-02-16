using Carter;
using Clinic.Application.Features.Doctor.Commands.AddDoctorShiftCommand;
using Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;
using Clinic.Application.Features.Doctor.Queries.GetAppointmentByDateQuery;
using Clinic.Domain.Entities;
using Clinic.Shared.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinic.API.Endpoints;

public class DoctorModule
    : CarterModule
{
    public DoctorModule() : base("")
    { }
    public override void AddRoutes(IEndpointRouteBuilder app) 
    {
        ///Get doctor appointments GET / doctors /{ id}/ appointments ? date =
        app.MapGet(
            "/doctors/{doctorId}/appointments",
            async (
                int doctorId,
                [AsParameters] GetAppointmentByDateQuery query,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct
                ) =>
            {
                query.DoctorId = doctorId;
                var appointments = await mediator
                    .ExecuteAsync< GetAppointmentByDateQuery, List< AppointmentSummaryDto>> (query, ct);
                return Results.Ok(appointments);
            })
            .WithTags("Doctors")
            .WithName("GetAppointments")
            .Produces<IEnumerable<Appointment>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        ///Add shift	POST	/doctors/{id}/shifts
        app.MapPost(
            "/doctors/{doctorId}/shifts",
            async(
                int doctorId,
                [FromBody] AddDoctorShiftCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct
                ) =>
            { 
                command.DoctorId = doctorId;
                var shiftId = await mediator
                    .ExecuteAsync<AddDoctorShiftCommand, int>(command, ct);

                return Results.Created(
                    $"/doctors/{doctorId}/shifts/{shiftId}",
                    new { shiftId });
            })
            .WithTags("Doctors")
            .WithName("AddShift")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        ///Add speciality  POST / doctors /{ id}/ specialities
        app.MapPost(
            "/doctors/{doctorId}/specialities",
            async (
                int doctorId,
                [FromBody] AddDoctorSpecialityCommand command,
                [FromServices] OperationExecutor mediator,
                CancellationToken ct
                ) =>
            {
                command.DoctorId = doctorId;
                var specialityId = await mediator
                    .ExecuteAsync<AddDoctorSpecialityCommand, int>(command, ct);
                
                return Results.Created(
                    $"/doctors/{doctorId}/specialities/{specialityId}",
                    new { specialityId });
            })
            .WithTags("Doctors")
            .WithName("AddSpeciality")
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
    }
}
