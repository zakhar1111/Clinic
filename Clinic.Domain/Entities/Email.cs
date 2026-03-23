using System.Text.RegularExpressions;

namespace Clinic.Domain.Entities;

public sealed record Email
{
    public string Value { get; }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Invalid email");
        
        var normalized = value.Trim().ToLower();

        if (normalized.Contains(".."))
            throw new ArgumentException("Invalid email format");
        if (!_regex.IsMatch(normalized))
            throw new ArgumentException("Invalid email format");

        return new Email(normalized);
    }

    public override string ToString() => Value;

    private static readonly Regex _regex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$");
}
