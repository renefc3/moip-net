using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Net4
{
    public sealed class OrdersApi : BaseClient
    {
        public OrdersApi(Uri apiUri, string apiToken, string apiKey) : base(apiUri, apiToken, apiKey)
        {
        }

        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#criar-pedido">Criar um Pedido</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreateOrdersResponse CreateOrder(CreateOrdersRequest req)
        {
            return DoPost<CreateOrdersRequest, CreateOrdersResponse>(new Uri("v2/orders"), req);
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#criar-pedido">Criar um Pedido</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreateOrdersResponse> CreateOrderAsync(CreateOrdersRequest req)
        {
            return await DoPostAsync<CreateOrdersRequest, CreateOrdersResponse>(new Uri("v2/orders"), req);
        }

        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#consultar-pedido">Consultar Pedido</see> 
        /// </summary>
        /// <param name="IdOrder"></param>
        /// <returns></returns>
        public GetOrderResponse GetOrder(string IdOrder)
        {
            return DoGet<GetOrderResponse>(new Uri($"v2/orders/{IdOrder}"));
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#consultar-pedido">Consultar Pedido</see> 
        /// </summary>
        /// <param name="IdOrder"></param>
        /// <returns></returns>
        public async Task<GetOrderResponse> GetOrderAsync(string IdOrder)
        {
            return await DoGetAsync<GetOrderResponse>(new Uri($"v2/orders/{IdOrder}"));
        }

    }
    public class GetOrderResponse
    {
        public string Id { get; set; }
        public string OwnId { get; set; }
        public OrderStatusType? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TotaisAmountsCreateOrdersResponse Amount { get; set; }
        public List<OrderItemCreateOrdersResponse> Items { get; set; }
        public ClienteCreateOrdersResponse Customer { get; set; }
        public List<OrderEvent> Events { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public List<ReceiverCreateOrdersResponse> Receivers { get; set; }


        public LinksCreateOrdersResponse _links { get; set; }
    }

    public class CreateOrdersRequest
    {
        public string OwnId { get; set; }
        public AmountsCreateOrdersRequest Amount { get; set; }
        public List<OrderItemCreateOrdersRequest> Items { get; set; }
        public ClienteCreateOrdersRequest Customer { get; set; }
        public List<ReceiverCreateOrdersRequest> Receivers { get; set; }
    }
    public class ReceiverCreateOrdersRequest
    {
        public ReceiverType? Type { get; set; }
        public bool FeePayor { get; set; }
        public MoipAccountReceiverCreateOrdersRequest moipAccount { get; set; }
        public AmountReceiverCreateOrdersRequest Amount { get; set; }
    }
    public class MoipAccountReceiverCreateOrdersRequest
    {
        public string Id { get; set; }

    }
    public class AmountReceiverCreateOrdersRequest
    {
        public int Percentual { get; set; }

    }

    public class ClienteCreateOrdersRequest
    {
        public string OwnId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public PhoneDto Phone { get; set; }
        public DocumentDto TaxDocument { get; set; }
        public AddressDto ShippingAddress { get; set; }
    }

    public class AmountsCreateOrdersRequest
    {
        public CurrencyType? Currency { get; set; }
        public TotaisAmountsCreateOrdersRequest Subtotals { get; set; }
    }

    public class TotaisAmountsCreateOrdersRequest
    {
        public decimal? Shipping { get; set; }
    }


    public class OrderItemCreateOrdersRequest
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
    }
    public class SubTotaisTotaisAmountsCreateOrdersResponse
    {
        public decimal? Shipping { get; set; }
        public decimal? Addition { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Items { get; set; }
    }

    public class TotaisAmountsCreateOrdersResponse
    {
        public decimal? Total { get; set; }
        public decimal? Fees { get; set; }
        public decimal? Refunds { get; set; }
        public decimal? Liquid { get; set; }
        public decimal? OtherReceivers { get; set; }
        public CurrencyType? Currency { get; set; }
        public SubTotaisTotaisAmountsCreateOrdersResponse Subtotals { get; set; }
    }
    public class MoipAccountClienteCreateOrdersResponse
    {
        public string Id { get; set; }

    }
    public class SelfLinksClienteCreateOrdersResponse
    {
        public string Href { get; set; }
    }
    public class HostedAccountLinksClienteCreateOrdersResponse
    {
        public string RedirectHref { get; set; }
    }
    public class LinksClienteCreateOrdersResponse
    {
        public SelfLinksClienteCreateOrdersResponse Self { get; set; }
        public HostedAccountLinksClienteCreateOrdersResponse HostedAccount { get; set; }
    }
    public class ClienteCreateOrdersResponse
    {
        public string OwnId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public MoipAccountClienteCreateOrdersResponse moipAccount { get; set; }
        public LinksClienteCreateOrdersResponse _links { get; set; }
        public PhoneDto Phone { get; set; }
        public DocumentDto TaxDocument { get; set; }
        public AddressDto ShippingAddress { get; set; }
    }

    public class OrderItemCreateOrdersResponse
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
    }

    public class CreateOrdersResponse
    {
        public string Id { get; set; }
        public string OwnId { get; set; }
        public OrderStatusType? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TotaisAmountsCreateOrdersResponse Amount { get; set; }
        public List<OrderItemCreateOrdersResponse> Items { get; set; }
        public ClienteCreateOrdersResponse Customer { get; set; }
        public List<OrderEvent> Events { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public List<ReceiverCreateOrdersResponse> Receivers { get; set; }


        public LinksCreateOrdersResponse _links { get; set; }

    }

    public class CheckoutMoipLinksCreateOrdersResponse
    {
        public HostedAccountLinksClienteCreateOrdersResponse PayCheckout { get; set; }
        public HostedAccountLinksClienteCreateOrdersResponse PayCreditCard { get; set; }
        public HostedAccountLinksClienteCreateOrdersResponse PayBoleto { get; set; }
        public HostedAccountLinksClienteCreateOrdersResponse PayOnlineBankDebitItau { get; set; }
    }

    public class LinksCreateOrdersResponse
    {
        public SelfLinksClienteCreateOrdersResponse Self { get; set; }
        public CheckoutMoipLinksCreateOrdersResponse Checkout { get; set; }
    }


    public class MoipAccountReceiverCreateOrdersResponse
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Fullname { get; set; }

    }
    public class TotaisAmountsReceiverCreateOrdersResponse
    {
        public decimal? Total { get; set; }
        public decimal? Fees { get; set; }
        public decimal? Refunds { get; set; }
    }

    public class ReceiverCreateOrdersResponse
    {
        public bool FeePayor { get; set; }
        public ReceiverType? Type { get; set; }
        public MoipAccountReceiverCreateOrdersResponse moipAccount { get; set; }
        public TotaisAmountsReceiverCreateOrdersResponse Amount { get; set; }
    }

    public class OrderEvent
    {
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

}
