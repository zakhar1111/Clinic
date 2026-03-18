namespace Clinic.Domain.Entities;

public record Phone
{
    public string Value { get; }

    private Phone(string value) => Value = value;

    public static Phone Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Invalid phone");

        return new Phone(value);
    }
}
