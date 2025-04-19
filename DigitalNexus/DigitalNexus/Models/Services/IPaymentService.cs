using DigitalNexus.Models.Entities;

namespace DigitalNexus.Models.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(Payment payment);
        Payment GetPaymentDetails(int paymentId);
    }
}
