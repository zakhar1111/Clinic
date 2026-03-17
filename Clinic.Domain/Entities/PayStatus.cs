namespace Clinic.Domain.Entities;

public class PayStatus
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    private PayStatus() { } 
    public static PayStatus Seed(int id, string name) 
        => new PayStatus{Id = id,Name = name};
}

public enum PayStatusEnum
{
    Created = 1,
    Authorized = 2,
    Paid = 3,
    Failed = 4,
    Refunded = 5
}

//public readonly record struct PayStatusId
//{
//    public int Value { get; }

//    private PayStatusId(int value)
//    {
//        Value = value;
//    }

//    public static PayStatusId FromEnum(PayStatusEnum status)
//        => new((int)status);

//    public PayStatusEnum ToEnum()
//        => (PayStatusEnum)Value;

//    public static implicit operator int(PayStatusId id) => id.Value;
//    public static explicit operator PayStatusId(int value) => new(value);
//}

