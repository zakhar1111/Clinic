using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;
using Clinic.Application.Features.Doctor.Commands.AddDoctorShiftCommand;
using Clinic.Application.Features.Doctor.Commands.AddDoctorSpecialityCommand;
using Clinic.Application.Features.Patient.Commands.BookinfAppointmentCommand;
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

        services.AddScoped<IOperationHandler<BookinfAppointmentCommand, int>, BookingAppointmentHandler>();

        return services;
    }
}
