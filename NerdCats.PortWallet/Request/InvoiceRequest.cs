namespace NerdCats.PortWallet.Request
{
    public sealed class InvoiceRequest
    {
        public string call => "gen_invoice";
        public double amount { get; set; }
        public string currency => Constants.BD_CURRENCY_CODE;
        public string product_name { get; set; }
        public string product_description { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country => Constants.BD_COUNTRY_CODE;
        public string redirect_url { get; set; }
        public string ipn_url { get; set; }
        public string ship_to_name { get; set; }
        public string ship_to_email { get; set; }
        public string ship_to_phone { get; set; }
        public string ship_to_address { get; set; }
        public string ship_to_city { get; set; }
        public string ship_to_state { get; set; }
        public string ship_to_zipcode { get; set; }
        public string ship_to_country => Constants.BD_COUNTRY_CODE;
    }
}
