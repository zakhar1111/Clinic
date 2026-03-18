namespace Clinic.Domain.Entities;

public sealed record Email
{
    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            throw new ArgumentException("Invalid email");

        return new Email(value.Trim().ToLower());
    }

    public override string ToString() => Value;
}
