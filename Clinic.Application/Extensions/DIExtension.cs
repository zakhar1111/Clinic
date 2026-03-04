using Clinic.Application.Events.DoctorUserCreatedEvent;
using Clinic.Application.Events.NewUserCreatedEvent;
using Clinic.Application.Events.PatientUserCreatedEvent;
using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;
using Clinic.Application.Features.Doctor.Commands.AddDiagnosticCommand;
using Clinic.Application.Features.Doctor.Commands.AddDoctorCommand;
using Clinic.Application.Features.Doctor.Commands.AddDoctorShiftCommand;
using Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;
using Clinic.Application.Features.Doctor.Commands.AddNoteCommand;
using Clinic.Application.Features.Doctor.Commands.AddPrescriptionCommand;
using Clinic.Application.Features.Doctor.Queries.GetAppointmentByDateQuery;
using Clinic.Application.Features.Patient.Commands.AddPaymentCommand;
using Clinic.Application.Features.Patient.Commands.AttachInsuranceCommand;
using Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;
using Clinic.Shared.Events;
using Clinic.Shared.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Application.Extensions;

public static class DIExtension
{
    public static IServiceCollection AddClinicApplicationServices(
        this IServiceCollection services
        )
    {
        services.AddScoped<IOperationHandler<PayForAppointmentCommand, int>, PayForAppointmentHandler>();
        
        services.AddScoped<IOperationHandler<AddDoctorSpecialityCommand, int>, AddDoctorSpecialityHandler>();
        services.AddScoped<IOperationHandler<AddDoctorShiftCommand, int>, AddDoctorShiftHandler>();
        services.AddScoped<IOperationHandler<GetAppointmentByDateQuery, List<AppointmentSummaryDto>>, GetAppointmentByDateHandler>();
        services.AddScoped<IOperationHandler<AddPrescriptionCommand, int>, AddPrescriptionHandler>();
        services.AddScoped<IOperationHandler<AddNoteCommand, int>, AddNoteHandler>();
        services.AddScoped<IOperationHandler<AddDiagnosticCommand, int>, AddDiagnosticHandler>();
        services.AddScoped<IOperationHandler<AddDoctorCommand, int>, AddDoctorHandler>();

        services.AddScoped<IOperationHandler<BookinfAppointmentCommand, int>, BookingAppointmentHandler>();
        services.AddScoped<IOperationHandler<AttachInsuranceCommand, int>, AttachInsuranceHandler>();
        services.AddScoped<IOperationHandler<AddPaymentCommand, int>, AddPaymentHandler>();

        services.AddScoped<OperationExecutor>();

        services.AddScoped<IIntegrationEventHandler<NewUserCreatedEvent>,NewUserCreatedEventHandler>();
        services.AddScoped<IIntegrationEventHandler<DoctorUserCreatedEvent>, DoctorUserCreatedEventHandler>();
        services.AddScoped<IIntegrationEventHandler<PatientUserCreatedEvent>, PatientUserCreatedEventHandler>();

        return services;
    }
}
