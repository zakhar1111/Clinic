using Clinic.Domain.Entities;

namespace Clinic.Application.Services;

public class PaymentService //[TODO] Consider  for clarity  payment orchesration handler
{
    public void ProcessPayment(
        Appointment appointment, 
        decimal amount, 
        int method
    )
    {
        var payment = appointment.AddPayment(amount, method);
        payment.MarkAuthorized();
        payment.MarkPaid();

        if (appointment.CalculateTotalPayments() >= appointment.Price)
            appointment.MarkAsCompleted();
    }
}

