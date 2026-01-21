using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Application.Extensions;

public static class DIExtension
{
    public static IServiceCollection AddClinicApplicationServices(
        this IServiceCollection services
        )
    {
        return services;
    }
}
