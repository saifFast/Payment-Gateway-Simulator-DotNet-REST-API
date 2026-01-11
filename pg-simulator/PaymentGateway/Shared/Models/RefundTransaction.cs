using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Shared.Models
{
    public class RefundTransaction
    {
        [Key]
        public string RefundId { get; set; } = Guid.NewGuid().ToString();
        public string TransactionId { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string Status { get; set; } = "PENDING";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
