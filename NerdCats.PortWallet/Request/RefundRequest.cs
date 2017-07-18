namespace NerdCats.PortWallet.Request
{
    public class RefundRequest
    {
        public string call => "refund_request";
        public double amount { get; set; }
        public string invoice { get; set; }
    }
}
