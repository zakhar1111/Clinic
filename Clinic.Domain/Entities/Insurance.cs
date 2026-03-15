namespace Clinic.Domain.Entities;

public class Insurance
{
    public int Id { get; private  set; }
    public string Provider { get; private set; }
    public int Coverage { get;private set; }

    private Insurance() { } // EF

    public static Insurance Create(
        string provider,
        int coverage
        )
    {
        if (string.IsNullOrWhiteSpace(provider))
            throw new ArgumentNullException( "Invalid Provider");

        if (coverage < 0 || coverage > 100)
            throw new ArgumentOutOfRangeException(nameof(coverage));

        return new Insurance
        {
            Provider = provider,
            Coverage = coverage
        };
    }
}
