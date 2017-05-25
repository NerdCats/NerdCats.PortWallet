namespace NerdCats.PortWallet
{
    public class WalletInvoice: IWalletData
    {
        public string invoice_id { get; set; }
        public string amount { get; set; }
        public string buyer_email { get; set; }
        public string buyer_name { get; set; }
        public string buyer_phone { get; set; }
        public string buyer_address { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public string currency { get; set; }
        public string payer_account { get; set; }
        public string status { get; set; }
        public string payer_name { get; set; }
        public string ip_address { get; set; }
        public string user_agent { get; set; }
        public string gateway_name { get; set; }
        public string gateway_url { get; set; }
        public string issuer_name { get; set; }
        public string issuer_phone { get; set; }
        public string issuer_website { get; set; }
        public string card_brand { get; set; }
        public string card_type { get; set; }
        public string gateway_txn_id { get; set; }
        public string reason { get; set; }
        public string card_category { get; set; }
        public string issuer_country_iso2 { get; set; }
        public string issuer_country { get; set; }
    }
}
