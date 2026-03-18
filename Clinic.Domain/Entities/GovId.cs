namespace Clinic.Domain.Entities;

public sealed record GovId
{
    public string Value { get; }

    private GovId(string value) => Value = value;

    public static GovId Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("GovId required");

        return new GovId(value.Trim());
    }

    public override string ToString() => Value;
}
