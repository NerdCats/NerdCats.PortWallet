namespace NerdCats.PortWallet.Request
{
    public class PaymentVerify
    {
        public string call => "ipn_validate";
        public double Amount { get; set; }
        public InvoiceRequest Invoice { get; set; }
    }
}
