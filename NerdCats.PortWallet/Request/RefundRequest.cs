namespace NerdCats.PortWallet.Request
{
    public class RefundRequest
    {
        public string call => "refund_request";
        public double amount { get; set; }
        public InvoiceRequest invoice { get; set; }
    }
}
