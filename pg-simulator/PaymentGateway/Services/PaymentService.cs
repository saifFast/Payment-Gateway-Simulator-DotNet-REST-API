using PaymentGateway.Shared.Models;
using PaymentGateway.Shared.DTOs.Requests;
using PaymentGateway.Shared.DTOs.Responses;

namespace PaymentGateway.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repo;
        private readonly Random _rng = new();

        public PaymentService(IPaymentRepository repo)
        {
            _repo = repo;
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            try
            {
                var txn = new PaymentTransaction()
                {
                    OrderId = request.OrderId,
                    CustomerId = request.CustomerId,
                    Amount = request.Amount,
                    Currency = request.Currency
                };

                txn.Status = _rng.NextDouble() > 0.37 ? "SUCCESS" : "FAILED";

                await _repo.AddPaymentAsync(txn);

                
                return new PaymentResponse
                {
                    TransactionId = txn.TransactionId,
                    Status = txn.Status,
                    Message = txn.Status == "SUCCESS" ? "Payment processed successfully" : "Payment failed (simulated)"
                };
            }
            catch
            {
                return new PaymentResponse
                {
                    TransactionId = "-1",
                    Status = "Failed",
                    Message = "Payment failed (simulated)"
                };
            }
        }

        public async Task<RefundResponse> ProcessRefundAsync(RefundRequest refundRequest)
        {
            var txn = await _repo.GetPaymentByIdAsync(refundRequest.TransactionId);

            if (txn == null || txn.Status == "SUCCESS")
                return new RefundResponse() { RefundId = "-1", Status = "Transaction Not found", Message = "Failed to Process Refund" };

            var roll = _rng.NextDouble();
            var refundStatus = roll < 0.8 ? "SUCCESS" : "FAILED"; // 80% refund success
            var refundTxn = new RefundTransaction() { TransactionId = refundRequest.TransactionId, Amount = refundRequest.Amount, Status = "REFUND", CreatedAt = DateTime.Now };

            await _repo.AddRefundAsync(refundTxn);
            
            return new RefundResponse
            {
                RefundId = refundTxn.RefundId,
                Status = refundTxn.Status,
                Message = refundTxn.Status == "SUCCESS" ? "Refund processed" : "Refund failed (simulated)"
            };
        }

        public async Task<object?> GetStatusAsync(string transactionId)
        {
            var txn = await _repo.GetPaymentByIdAsync(transactionId);
            if (txn == null) return null;

            return new
            {
                txn.TransactionId,
                txn.Status,
                txn.Amount,
                txn.Currency,
                RefundStatus = "NONE",
                txn.CreatedAt
            };
        }
    }
}