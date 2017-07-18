namespace NerdCats.PortWallet.Request
{
    public class PaymentVerify
    {
        public string call => "ipn_validate";
        public double amount { get; set; }
        public string invoice { get; set; }
    }
}
