using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic.Infrastructure.Persistence.Convertors;

public class MoneyConverter: ValueConverter<Money, decimal>
{
    public MoneyConverter()
        : base(
            v => v.Amount,
            v => Money.Create(v))
    { 
    }
}
