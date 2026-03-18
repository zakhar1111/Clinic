using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic.Infrastructure.Persistence.Convertors;

public class PhoneConverter : ValueConverter<Phone, string>
{
    public PhoneConverter()
        : base(
            v => v.Value,
            v => Phone.Create(v))
    {
    }
}
