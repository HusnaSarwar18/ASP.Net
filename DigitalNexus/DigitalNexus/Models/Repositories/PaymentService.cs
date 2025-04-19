using Dapper;
using DigitalNexus.Models.Entities;
using DigitalNexus.Models.Services;
using System.Data;

namespace DigitalNexus.Models.Repositories
{
    public class PaymentService : IPaymentService
    {
        private readonly IDbConnection _db;

        public PaymentService(IDbConnection db)
        {
            _db = db;
        }

        public void ProcessPayment(Payment payment)
        {
            string sql = "INSERT INTO Payments (OrderId, PaymentMethod, PaymentStatus, PaymentDate) " +
                         "VALUES (@OrderId, @PaymentMethod, @PaymentStatus, @PaymentDate)";
            _db.Execute(sql, payment);
        }

        public Payment GetPaymentDetails(int paymentId)
        {
            string sql = "SELECT * FROM Payments WHERE PaymentId = @PaymentId";
            return _db.QuerySingleOrDefault<Payment>(sql, new { PaymentId = paymentId });
        }
    }
}

