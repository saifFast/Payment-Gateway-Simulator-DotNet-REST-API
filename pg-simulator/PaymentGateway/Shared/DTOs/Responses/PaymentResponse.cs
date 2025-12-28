namespace PaymentGateway.Shared.DTOs.Responses
{
    public class PaymentResponse
    {
        public string TransactionId { get; set; } = "";
        public string Status { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
