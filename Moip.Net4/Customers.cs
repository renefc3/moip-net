using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Net4
{
    public sealed class CustomersApi :BaseClient
    {
        public CustomersApi(Uri apiUri, string apiToken, string apiKey) : base(apiUri, apiToken, apiKey)
        {

        }

        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#criar-um-cliente">Criar um cliente </see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreateCustomersResponse CriarCliente(CreateCustomersRequest req)
        {
            return DoPost<CreateCustomersRequest, CreateCustomersResponse>(new Uri("v2/customers"), req);
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#criar-um-cliente">Criar um cliente</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreateCustomersResponse> CriarClienteAsync(CreateCustomersRequest req)
        {
            return await DoPostAsync<CreateCustomersRequest, CreateCustomersResponse>(new Uri("v2/customers"), req);
        }


        /// <summary>
        /// Chamada Sincrona da API <see href="https://dev.moip.com.br/v2.0/reference#adicionar-cartao-de-credito">Adicionar um cartão de crédito</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreateCustomersResponse AdicionarCartaoCredito(CreateCustomersRequest req)
        {
            return DoPost<CreateCustomersRequest, CreateCustomersResponse>(new Uri("v2/customers"), req);
        }

        /// <summary>
        /// Chamada Assincrona da API <see href="https://dev.moip.com.br/v2.0/reference#adicionar-cartao-de-credito">Adicionar um cartão de crédito</see> 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CreateCustomersResponse> AdicionarCartaoCreditoAsync(CreateCustomersRequest req)
        {
            return await DoPostAsync<CreateCustomersRequest, CreateCustomersResponse>(new Uri("v2/customers"), req);
        }










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

    public enum OrderStatusType
    {
        CREATED,
        WAITING,
        PAID,
        NOT_PAID,
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
