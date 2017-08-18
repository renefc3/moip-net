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
        /// <param name="idCustomer">Id do Cliente no Moip</param>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreditCardAddCreditCardResponse AddCreditCard(string idCustomer, AddCreditCardRequest req)
        {
            return DoPost<AddCreditCardRequest, CreditCardAddCreditCardResponse>(new Uri($"v2/customers/{idCustomer}/fundinginstruments"), req);
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#adicionar-cartao-de-credito">Adicionar um cartão de crédito</see> 
        /// </summary>
        /// <param name="idCustomer">Id do Cliente no Moip</param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreditCardAddCreditCardResponse> AddCreditCardAsync(string idCustomer, AddCreditCardRequest req)
        {
            return await DoPostAsync<AddCreditCardRequest, CreditCardAddCreditCardResponse>(new Uri($"v2/customers/{idCustomer}/fundinginstruments"), req);
        }


        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#consultar-um-cliente">Consultar um cliente </see> 
        /// </summary>
        /// <param name="idCustomer">Id do Cliente no Moip</param>
        /// <returns></returns>
        public CreateCustomersResponse GetCustomer(string idCustomer)
        {
            return DoGet<CreateCustomersResponse>(new Uri($"v2/customers/{idCustomer}"));
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#consultar-um-cliente">Consultar um cliente</see> 
        /// </summary>
        /// <param name="idCustomer">Id do Cliente no Moip</param>
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
        /// <summary>
        /// REQUIRED
        /// Id próprio do cliente.Referência externa.Limite de caracteres: (65).
        /// </summary>
        public string OwnId { get; set; }
        /// <summary>
        /// REQUIRED
        /// Nome completo do cliente.Limite de caracteres: (90)
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// REQUIRED
        /// Email do cliente. Limite de caracteres: (45)
        /// </summary>
        public string Email { get; set; }

        public PhoneDto Phone { get; set; }

        /// <summary>
        /// Data de nascimento do cliente. date (AAAA-MM-DD)
        /// </summary>
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
        /// <summary>
        /// REQUIRED
        /// DDI (código internacional) do telefone. Valores possíveis: 55. Limite de caracteres: 2
        /// </summary>
        public int CountryCode { get; set; }
        /// <summary>
        /// REQUIRED
        /// Código de área do cliente. Limite de caracteres: (2)
        /// </summary>
        public int AreaCode { get; set; }
        /// <summary>
        /// REQUIRED
        /// Número de telefone do cliente. Limite de caracteres: 9
        /// </summary>
        public int Number { get; set; }
    }

    public class DocumentDto
    {
        /// <summary>
        /// Tipo do documento. Valores possíveis: CPF, CNPJ. Limite de caracteres: (4)
        /// </summary>
        public DocumentType Type { get; set; }
        /// <summary>
        /// Número do documento. Limite de caracteres: (11)
        /// </summary>
        public string Number { get; set; }
    }


    public class AddressDto
    {
        /// <summary>
        /// REQUIRED Logradouro do endereço
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// REQUIRED Número
        /// </summary>
        public string StreetNumber { get; set; }
        
        /// <summary>
        /// Complemento do endereço.
        /// </summary>
        public string Complement { get; set; }
        /// <summary>
        /// REQUIRED Bairro
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// REQUIRED Cidade
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// REQUIRED Estado
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// REQUIRED País em formato ISO-alpha3, exemplo BRA.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// REQUIRED O CEP do endereço de cobrança
        /// </summary>
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
        /// <summary>
        /// Pagamento criado.
        /// </summary>
        CREATED,
        /// <summary>
        /// Pagamento aguardando confirmação (Boleto não confirmado ou débito bancário pendente).
        /// </summary>
        WAITING,
        /// <summary>
        /// Pagamento de cartão aguardando análise.
        /// </summary>
        IN_ANALYSIS,
        /// <summary>
        /// O valor do pagamento está reservado no cartão de crédito do comprador.
        /// </summary>
        PRE_AUTHORIZED,
        /// <summary>
        /// Pagamento autorizado.
        /// </summary>
        AUTHORIZED,
        /// <summary>
        /// Pagamento cancelado (Pagamentos com cartão podem ser cancelados pelo Moip ou pelo emissor do cartão, boletos são cancelados 5 dias após vencimento, débito bancário é cancelado em caso de falha).
        /// </summary>
        CANCELLED,
        /// <summary>
        /// Pagamento reembolsado (quem processa reembolsos são Moip e/ou Merchant).
        /// </summary>
        REFUNDED,
        /// <summary>
        /// Pagamento revertido (Chargeback. O cliente contesta a transação diretamente no emissor).
        /// </summary>
        REVERSED,

        /// <summary>
        /// Pagamento liquidado. Significa que o valor da transação foi “liberado” na conta, para que o merchant possa sacar para sua conta bancária.
        /// </summary>
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
