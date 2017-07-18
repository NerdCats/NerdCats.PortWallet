﻿namespace NerdCats.PortWallet.Request
{
    public class PaymentVerify
    {
        public string call => "ipn_validate";
        public double amount { get; set; }
        public InvoiceRequest invoice { get; set; }
    }
}
