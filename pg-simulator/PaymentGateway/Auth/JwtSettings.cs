namespace PaymentGateway.Auth
{
    public class JwtSettings
    {
        public string Key { get; set; } = "ReplaceThisWithStrongerKey";
        public string Issuer { get; set; } = "PaymentGateway";
        public string Audience { get; set; } = "PaymentGatewayUsers";
        public int ExpMinutes { get; set; } = 120;
    }
}
