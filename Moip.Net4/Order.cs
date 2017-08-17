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
        public int? Shipping { get; set; }
    }


    public class OrderItemCreateOrdersRequest
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
        public updatedAt? CreatedAt { get; set; }
        public Valores Amount { get; set; }
        public List<ItemPedido> Items { get; set; }
        public PreferenciasCheckout CheckoutPreferences { get; set; }
        public Endereco ShippingAddress { get; set; }
        public Cliente Customer { get; set; }
        public List<Pagamento> Payments { get; set; }
        public List<Reembolso> Refunds { get; set; }
        public List<Lancamento> Entries { get; set; }
        public List<Evento> Events { get; set; }
        public List<Recebedores> Receivers { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Links _links { get; set; }

    }

}
