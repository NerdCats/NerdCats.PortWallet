namespace NerdCats.PortWallet
{
    public enum ResponseStatus
    {
        PENDING = 100,
        CANCELLED = 120,
        ACCEPTED = 200,
        REFUND_PENDING = 210,
        REFUND_PROCESSING = 215,
        REFUNDED = 220,
        PARTIALLY_REFUNDED = 230,
        CHARGED_BACK = 240,
        REJECTED = 300,
        INVALID_REQUEST = 400,
        NOT_ALLOWED = 500
    }
}
