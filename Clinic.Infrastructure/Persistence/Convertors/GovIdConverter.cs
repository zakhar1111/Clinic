using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic.Infrastructure.Persistence.Convertors;

public class GovIdConverter : ValueConverter<GovId, string>
{
    public GovIdConverter()
        : base(
            v => v.Value,
            v => GovId.Create(v))
    {
    }
}
