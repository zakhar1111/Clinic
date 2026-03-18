namespace Clinic.Domain.Entities;

public sealed record Coverage
{
    public string Provider { get; }
    public string Plan { get; }

    private Coverage(string provider, string plan)
    {
        Provider = provider;
        Plan = plan;
    }

    public static Coverage Create(string provider, string plan)
    {
        if (string.IsNullOrWhiteSpace(provider))
            throw new ArgumentException("Provider required");

        return new Coverage(provider, plan);
    }
}
