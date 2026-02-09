namespace Clinic.Domain.Entities;

public class Payment
{
    public int Id { get; set; }

    public decimal Amount { get; set; }
    
    public DateTime PaidAt { get; set; }
    //public DateTime? RefundedAt { get; set; } [TODO] Add if refund tracking is needed
    //public DateTime CreatedAt { get; set; }   [TODO] Add if creation timestamp is needed

    public int AppointmentId { get; set; }
    public int PayTypeId { get; set; }
    public int PayStatusId { get; set; } // State Machine: Created -> Authorized -> Paid/Failed -> Refunded

    public Appointment Appointment { get; set; }
    public PayType PayType { get; set; }
    public PayStatus PayStatus { get; set; }

    public void MarkAuthorized()
    {
        EnsureStatus(1);//(PaymentStatuses.Created);
        PayStatusId = 2;// PaymentStatuses.Authorized;
    }

    public void MarkPaid()
    {
        EnsureStatus(2);//(PaymentStatuses.Authorized);
        PayStatusId = 3;// PaymentStatuses.Paid;
        PaidAt = DateTime.UtcNow;
    }

    public void MarkFailed()
    {
        EnsureNotFinal();
        PayStatusId = 4;// PaymentStatuses.Failed;
    }

    public void Refund()
    {
        EnsureStatus(3);//(PaymentStatuses.Paid);
        PayStatusId = 5;// PaymentStatuses.Refunded;
        //RefundedAt = DateTime.UtcNow;
    }

    private void EnsureStatus(int expected)
    {
        if (PayStatusId != expected)
            throw new InvalidOperationException(
                $"Invalid payment transition from status {PayStatusId}");
    }

    private void EnsureNotFinal()
    {
        if (PayStatusId is 3 or 5)
            throw new InvalidOperationException(
                "Payment is already finalized.");
    }

}
