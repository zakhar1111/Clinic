namespace Clinic.Domain.Entities;

public class PayType
{
    public int Id { get; set; }
    public string Name { get;  set; } 
}

public enum PayTypeEnum
{
    Cash = 1,
    CreditCard = 2,
    Insurance = 3
}