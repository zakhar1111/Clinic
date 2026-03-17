namespace Clinic.Domain.Entities;

public class PayStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum PayStatusEnum
{
    Created = 1,
    Authorized = 2,
    Paid = 3,
    Failed = 4,
    Refunded = 5
}


