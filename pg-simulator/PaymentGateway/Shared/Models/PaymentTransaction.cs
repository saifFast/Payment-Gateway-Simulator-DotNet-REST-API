namespace PaymentGateway.Shared.Models
{
    public class PaymentTransaction
    {
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string Currency { get; set; } = "PKR";
        public string Status { get; set; } = "PENDING";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
