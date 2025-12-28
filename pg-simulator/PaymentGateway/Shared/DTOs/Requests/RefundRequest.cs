namespace PaymentGateway.Shared.DTOs.Requests
{
    public class RefundRequest
    {
        public string TransactionId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
