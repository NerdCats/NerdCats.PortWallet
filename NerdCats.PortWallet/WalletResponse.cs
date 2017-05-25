namespace NerdCats.PortWallet
{
    public class WalletResponse<T> where T: IWalletData
    {
        public ResponseStatus status { get; set; }
        public T data { get; set; }
    }
}
