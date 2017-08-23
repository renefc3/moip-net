using System.Collections.Generic;

namespace Moip.Net4
{
    public class CreateOrdersRequest
    {
        public string OwnId { get; set; }
        public AmountsCreateOrdersRequest Amount { get; set; }
        public List<OrderItemCreateOrdersRequest> Items { get; set; }
        public ClienteCreateOrdersRequest Customer { get; set; }
        public List<ReceiverCreateOrdersRequest> Receivers { get; set; }
    }

}
