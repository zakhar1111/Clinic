using System.Text.RegularExpressions;

namespace Clinic.Domain.Entities;

public record Phone
{
    private static readonly Regex _regex =
        new(@"^\+?[1-9]\d{7,14}$");
    public string Value { get; }

    private Phone(string value) => Value = value;

    public static Phone Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Invalid phone");

        // normalize (remove everything except digits)
        var digits = Regex.Replace(value, @"\D", "");

        if (digits.Length < 8 || digits.Length > 15)
            throw new ArgumentException("Invalid phone length");

        var normalized = "+" + digits;

        if (!_regex.IsMatch(normalized))
            throw new ArgumentException("Invalid phone format");

        return new Phone(normalized);
    }
}
