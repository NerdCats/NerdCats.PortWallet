using System;
using System.Collections.Generic;
using System.Text;

namespace NerdCats.PortWallet.Request
{
    public class PaymentVerify
    {
        public string call => "ipn_validate";
        public double amount { get; set; }
        public InvoiceRequest Invoice { get; set; }
    }
}
