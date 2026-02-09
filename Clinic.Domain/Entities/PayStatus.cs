namespace Clinic.Domain.Entities;

public class PayStatus
{
    public int Id { get; set; }
    public string Name { get; set; } 
}

// - Created
// - Authorized
// - Paid
// - Failed
// - Refunded