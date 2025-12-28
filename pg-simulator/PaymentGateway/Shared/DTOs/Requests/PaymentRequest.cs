namespace PaymentGateway.Shared.DTOs.Requests
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "PKR";
        public string CustomerId { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = "card";
    }

}
