namespace Moip.Net4
{
    public class ReceiverCreateOrdersRequest
    {
        public ReceiverType? Type { get; set; }
        public bool FeePayor { get; set; }
        public MoipAccountReceiverCreateOrdersRequest moipAccount { get; set; }
        public AmountReceiverCreateOrdersRequest Amount { get; set; }
    }

}
