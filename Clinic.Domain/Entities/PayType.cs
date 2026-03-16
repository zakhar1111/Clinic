namespace Clinic.Domain.Entities;

public class PayType
{
    public int Id { get; private set; }
    public string Name { get; private  set; }

    private PayType() { } // for EF core
    public static PayType Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("PayType name is invalid");

        return new PayType { Name = name };
    }

    public static PayType Seed(int id, string name) =>
        new PayType { Id = id, Name = name };

}
