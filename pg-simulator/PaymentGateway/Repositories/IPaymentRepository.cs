using PaymentGateway.Models;

public interface IPaymentRepository
{
    Task AddPaymentAsync(PaymentTransaction txn);
    Task<PaymentTransaction?> GetPaymentByIdAsync(string transactionId);
    Task UpdatePaymentAsync(PaymentTransaction txn);
    Task AddRefundAsync(RefundTransaction refund);
    Task<RefundTransaction?> GetRefundByIdAsync(string refundId);
}
