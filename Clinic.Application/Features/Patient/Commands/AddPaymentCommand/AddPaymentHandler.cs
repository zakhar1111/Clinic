using Clinic.Application.Repositories;
using Clinic.Shared.Messaging;

namespace Clinic.Application.Features.Patient.Commands.AddPaymentCommand;

//public class AddPaymentHandler(IAppointmentRepository appintmentRepository)
//    : IOperationHandler<AddPaymentCommand, int>
//{
//    private readonly IAppointmentRepository _appintmentRepository = appintmentRepository;

//    public async Task<int> HandleAsync(AddPaymentCommand request, CancellationToken ct = default)
//    {
//        var appointment = await _appintmentRepository
//            .GetByIdAsync(request.AppointmentId, ct)
//            ?? throw new InvalidOperationException("Appointment not found.");

//        var newPayment = appointment.AddPayment(
//            request.Amount,
//            request.PayTypeId
//        );

//        await _appintmentRepository.SaveAsync(appointment, ct);
//        return newPayment.Id;
//    }
//}
