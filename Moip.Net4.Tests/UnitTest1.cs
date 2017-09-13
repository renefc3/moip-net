using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moip.Net4;

namespace Moip.Net4.Tests
{


    public class BaseApiIntegratedTests
    {
        public Uri BaseUrl { get { return new Uri("URL"); } }
        public string apiToken { get { return "SEU_TOKEN"; } }
        public string apiKey { get { return "API_KEY"; } }


    }

    [TestClass]
    public class CustomersApiTests : BaseApiIntegratedTests
    {
        [TestMethod]
        public void CustomersApi_CreateCustomer()
        {
            CustomersApi api = new CustomersApi(BaseUrl, apiToken, apiKey);

            CreateCustomersRequest req = new CreateCustomersRequest();
            req.BirthDate = DateTime.Today.AddYears(-30);
            req.Email = "teste_cliente@moipNet4.com";
            req.Fullname = "Teste moip client 4";
            req.OwnId = "3";
            req.Phone = new PhoneDto()
            {
                AreaCode = 11,
                CountryCode = 55,
                Number = 98985959
            };
            req.ShippingAddress = new AddressDto()
            {
                City = "Sao Paulo",
                Complement = "A",
                Country = "BR",
                District = "SP",
                State = "SP",
                Street = "Sao paullo",
                StreetNumber = "12",
                ZipCode = "09090170"
            };
            req.TaxDocument = new DocumentDto()
            {
                Number = "95672830013",
                Type = DocumentType.CPF
            };



            var retorno = api.CreateCustomer(req);
            Assert.IsNotNull(retorno);
            Assert.IsNotNull(retorno.Id);
        }

        [TestMethod]
        public void CustomersApi_AddCreditCard()
        {
            CustomersApi api = new CustomersApi(BaseUrl, apiToken, apiKey);

            string idcliente = "CUS-1IO9IR204YI4";
            AddCreditCardRequest request = new AddCreditCardRequest();
            request.Method = MethodType.CREDIT_CARD;
            request.CreditCard = new CreditCardAddCreditCardRequest()
            {
                Cvc = 546,
                ExpirationMonth = 9,
                ExpirationYear = 2018,
                Holder = new HolderDto()
                {
                    Birthdate = DateTime.Now.AddYears(-25),
                    Fullname = "TESTE MOIP NET",
                    Phone = new PhoneDto()
                    {
                        AreaCode = 11,
                        CountryCode = 55,
                        Number = 98985959
                    },
                    TaxDocument = new DocumentDto()
                    {
                        Number = "95672830013",
                        Type = DocumentType.CPF
                    }
                },
                Number = "4556832098622729"
            };

            var retorno = api.AddCreditCard(idcliente, request);
        }
    }
}
