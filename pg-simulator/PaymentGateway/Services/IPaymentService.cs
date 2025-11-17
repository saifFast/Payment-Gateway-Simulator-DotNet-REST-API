using PaymentGateway.DTOs;

namespace PaymentGateway.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<RefundResponse> ProcessRefundAsync(RefundRequest request);
        Task<object?> GetStatusAsync(string transactionId);
    }
}
