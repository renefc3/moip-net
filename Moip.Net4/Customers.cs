using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Net4
{
    public sealed class CustomersApi : BaseClient
    {
        public CustomersApi(Uri apiUri, string apiToken, string apiKey) : base(apiUri, apiToken, apiKey)
        {

        }

        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#criar-um-cliente">Criar um cliente </see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreateCustomersResponse CreateCustomer(CreateCustomersRequest req)
        {
            return DoPost<CreateCustomersRequest, CreateCustomersResponse>(new Uri("v2/customers"), req);
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#criar-um-cliente">Criar um cliente</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreateCustomersResponse> CreateCustomerAsync(CreateCustomersRequest req)
        {
            return await DoPostAsync<CreateCustomersRequest, CreateCustomersResponse>(new Uri("v2/customers"), req);
        }


        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#adicionar-cartao-de-credito">Adicionar um cartão de crédito</see> 
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreditCardAddCreditCardResponse AddCreditCard(string idCustomer, AddCreditCardRequest req)
        {
            return DoPost<AddCreditCardRequest, CreditCardAddCreditCardResponse>(new Uri($"v2/customers/{idCustomer}/fundinginstruments"), req);
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#adicionar-cartao-de-credito">Adicionar um cartão de crédito</see> 
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreditCardAddCreditCardResponse> AddCreditCardAsync(string idCustomer, AddCreditCardRequest req)
        {
            return await DoPostAsync<AddCreditCardRequest, CreditCardAddCreditCardResponse>(new Uri($"v2/customers/{idCustomer}/fundinginstruments"), req);
        }


        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#consultar-um-cliente">Consultar um cliente </see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreateCustomersResponse GetCustomer(string idCustomer)
        {
            return DoGet<CreateCustomersResponse>(new Uri($"v2/customers/{idCustomer}"));
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#consultar-um-cliente">Consultar um cliente</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreateCustomersResponse> GetCustomerAsync(string idCustomer)
        {
            return await DoGetAsync<CreateCustomersResponse>(new Uri($"v2/customers/{idCustomer}"));
        }

        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#deletar-cartão-de-crédito">Deletar um cartão de crédito</see> 
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public System.Net.Http.HttpResponseMessage DeleteCreditCard(string idCreditCard)
        {
            return DoDelete(new Uri($"v2/fundinginstruments/{idCreditCard}"));
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#deletar-cartão-de-crédito">Deletar um cartão de crédito</see> 
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<System.Net.Http.HttpResponseMessage> DeleteCreditCardAsync(string idCreditCard)
        {
            return await DoDeleteAsync(new Uri($"v2/fundinginstruments/{idCreditCard}"));
        }

    }

    public class AddCreditCardResponse
    {
        public CreditCardAddCreditCardResponse CreditCard { get; set; }
    }
    public class CreditCardAddCreditCardResponse
    {
        public string Id { get; set; }
        public string Hash { get; set; }
        public BrandType Brand { get; set; }
        public string First6 { get; set; }
        public string Last4 { get; set; }

    }

    public class AddCreditCardRequest
    {
        public MethodType Method { get; set; }
        public CreditCardAddCreditCardRequest CreditCard { get; set; }
    }
    public class CreditCardAddCreditCardRequest
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
        public int? Cvc { get; set; }
        public HolderDto Holder { get; set; }

    }

    public class HolderDto
    {
        public string Fullname { get; set; }
        public string Birthdate { get; set; }
        public PhoneDto Phone { get; set; }
        public DocumentDto TaxDocument { get; set; }
    }



    public class CreateCustomersResponse
    {
        public string Id { get; set; }
        public string OwnId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public PhoneDto Phone { get; set; }
        public string BirthDate { get; set; }
        public DocumentDto TaxDocument { get; set; }
        public AddressDto ShippingAddress { get; set; }

        public override string ToString()
        {
            return OwnId;
        }

    }


    public class CreateCustomersRequest
    {
        public string OwnId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public PhoneDto Phone { get; set; }
        public string BirthDate { get; set; }
        public DocumentDto TaxDocument { get; set; }
        public AddressDto ShippingAddress { get; set; }

        public override string ToString()
        {
            return OwnId;
        }

    }

    public class PhoneDto
    {
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
        public override string ToString()
        {
            return string.Format("+{0} ({1}) {2}", CountryCode, AreaCode, Number);
        }
    }

    public class DocumentDto
    {
        public DocumentType Type { get; set; }
        public string Number { get; set; }
    }


    public class AddressDto
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }


    public enum BrandType
    {
        VISA,
        MASTERCARD,
        AMEX,
        DINERS,
        ELO,
        HIPER,
        HIPERCARD
    }
    public enum DocumentType
    {
        CPF,
        CNPJ
    }
    public enum MethodType
    {
        CREDIT_CARD,
        BOLETO,
        ONLINE_DEBIT,
        WALLET,
        MOIP_ACCOUNT
    }

    /// <summary>
    /// <see href="https://dev.moip.com.br/v2.0/reference#lista-de-status-possiveis-pedido">Documentação</see> 
    /// </summary>
    public enum OrderStatusType
    {
        /// <summary>
        /// Pedido criado. Mas ainda não possui nenhum pagamento. <see href="https://dev.moip.com.br/v2.0/reference#lista-de-status-possiveis-pedido">Mais Informações</see> 
        /// </summary>
        CREATED,

        /// <summary>
        ///Pedido aguardando confirmação de pagamento. Indica que há um pagamento de cartão em análise ou um boleto que ainda não foi confirmado pelo banco. <see href="https://dev.moip.com.br/v2.0/reference#lista-de-status-possiveis-pedido">Mais Informações</see> 
        /// </summary>
        WAITING,

        /// <summary>
        /// Pedido pago. O pagamento criado nesse pedido foi autorizado. <see href="https://dev.moip.com.br/v2.0/reference#lista-de-status-possiveis-pedido">Mais Informações</see> 
        /// </summary>
        PAID,


        /// <summary>
        /// Pedido não pago. O pagamento criado nesse pedido foi cancelado (Pagamentos com cartão podem ser cancelados pelo Moip ou pelo Emissor do cartão, boletos são cancelados 5 dias após vencimento, débito bancário é cancelado em caso de falha). <see href="https://dev.moip.com.br/v2.0/reference#lista-de-status-possiveis-pedido">Mais Informações</see> 
        /// </summary> PAID,
        NOT_PAID,

        /// <summary>
        /// Pedido revertido. Sofreu um chargeback ou foi completamente reembolsado. <see href="https://dev.moip.com.br/v2.0/reference#lista-de-status-possiveis-pedido">Mais Informações</see> 
        /// </summary>
        REVERTED
    }

    public enum CurrencyType
    {
        BRL
    }

    public enum PaymentStatusType
    {
        CREATED,
        WAITING,
        IN_ANALYSIS,
        PRE_AUTHORIZED,
        AUTHORIZED,
        CANCELLED,
        REFUNDED,
        REVERSED,
        SETTLED
    }

    public enum FeeType
    {
        TRANSACTION,
        PRE_PAYMENT
    }
    public enum CancelledByType
    {
        MOIP,
        ACQUIRER
    }
    public enum RefundStatusType
    {
        REQUESTED,
        COMPLETED,
        FAILED
    }
    public enum RefundType
    {
        FULL,
        PARTIAL
    }

    public enum BankAccountType
    {
        CHECKING,
        SAVING
    }

    public enum EntryStatusType
    {
        SCHEDULED,
        SETTLED
    }

    public enum OperationType
    {
        CREDIT,
        DEBIT
    }

    public enum ReceiverType
    {
        PRIMARY,
        SECONDARY
    }



}
