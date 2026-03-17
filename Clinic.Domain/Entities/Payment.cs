namespace Clinic.Domain.Entities;

public class Payment
{
    public int Id { get; private set; }

    public decimal Amount { get; private set; }
    
    public DateTime PaidAt { get; private  set; }
            //public DateTime? RefundedAt { get; set; } [TODO] Add if refund tracking is needed
            //public DateTime CreatedAt { get; set; }   [TODO] Add if creation timestamp is needed

    public int AppointmentId { get; private  set; }
    public int PayTypeId { get; private  set; }
    public int PayStatusId { get; private set; }// // State Machine: Created -> Authorized -> Paid/Failed -> Refunded

    public Appointment Appointment { get; private set; }
    public PayType PayType { get; private set; }
            //public PayStatus PayStatus { get; private set; }


    private Payment() { } // EF

    public static Payment Create(
        decimal amount,
        PayType payType,            //int payTypeId,
        Appointment appointment)    //int appointmentId)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(amount), "Payment amount must be positive.");
        if (payType is null)
            throw new ArgumentException("Invalid payType.");
        if (appointment is null)
            throw new ArgumentException("Invalid appointment.");

        return new Payment
        {
            Amount = amount,
            PayTypeId = payType.Id,
            PayType = payType,
            AppointmentId = appointment.Id,
            Appointment = appointment,
            PayStatusId = (int)PayStatusEnum.Created
        };
    }

    public void MarkAuthorized()
    {
        EnsureStatus(PayStatusEnum.Created);
        PayStatusId = (int)PayStatusEnum.Authorized;
    }

    public void MarkPaid()
    {
        EnsureStatus(PayStatusEnum.Authorized);
        PayStatusId = (int)PayStatusEnum.Paid   ;
        PaidAt = DateTime.UtcNow;
    }

    public void MarkFailed()
    {
        EnsureNotFinal();
        PayStatusId = (int)PayStatusEnum.Failed;
    }

    public void Refund()
    {
        EnsureStatus(PayStatusEnum.Paid);
        PayStatusId = (int)PayStatusEnum.Refunded;
        //RefundedAt = DateTime.UtcNow;
    }

    private void EnsureStatus(PayStatusEnum expected)
    {
        if (PayStatusId != (int)expected)
            throw new InvalidOperationException(
                $"Invalid payment transition from status {expected}");
    }

    private void EnsureNotFinal()
    {
        //if (PayStatusId is 3 or 5)
        if (PayStatusId == (int)PayStatusEnum.Paid ||
            PayStatusId == (int)PayStatusEnum.Refunded)
        {
            throw new InvalidOperationException(
                "Payment is already finalized.");
        }
    }

}
