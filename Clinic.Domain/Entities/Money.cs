namespace Clinic.Domain.Entities;

public sealed record Money
{
    public decimal Amount { get; }

    private Money(decimal amount) => Amount = amount;

    public static Money Create(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");

        return new Money(amount);
    }
}
