namespace Clinic.Domain.Entities;

public class Insurance
{
    public int Id { get; set; }
    public string Provider { get; set; }
    public int Coverage { get; set; }

    public static Insurance Create(
        string provider,
        int coverage
        )
    {
        if (string.IsNullOrWhiteSpace(provider))
            throw new ArgumentNullException(nameof(provider));
        if (coverage < 0 || coverage > 100)
            throw new ArgumentOutOfRangeException(nameof(coverage));

        return new Insurance
        {
            Provider = provider,
            Coverage = coverage
        };
    }
}
