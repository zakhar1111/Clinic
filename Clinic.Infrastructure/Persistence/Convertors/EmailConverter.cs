using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic.Infrastructure.Persistence.Convertors;

public class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter()
        : base(
            v => v.Value,
            v => Email.Create(v))
    {
    }
}
