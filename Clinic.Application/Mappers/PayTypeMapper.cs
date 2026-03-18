using Clinic.Application.Features.Appointment.Commands.PayForAppointmentCommand;
using Clinic.Domain.Entities;

namespace Clinic.Application.Mappers;

public static class PayTypeMapper
{
    public static PayType ToDomain(this PayTypeDto dto)
    {
        if (dto is null)
            throw new ArgumentNullException(nameof(dto));

        return PayType.Seed(dto.Id, dto.Name);
    }
    public static PayTypeDto ToDto(this PayType domain)
    {
        if (domain is null)
            throw new ArgumentNullException(nameof(domain));

        return new PayTypeDto(domain.Id, domain.Name);
    }
}
