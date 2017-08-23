namespace Moip.Net4
{
    public class AmountsCreateOrdersRequest
    {
        public CurrencyType? Currency { get; set; }
        public TotaisAmountsCreateOrdersRequest Subtotals { get; set; }
    }

}
