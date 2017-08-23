using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moip.Net4.OAuth
{
    public class OAuthAPI : BaseClient
    {
        public OAuthAPI(Uri apiUri, string apiToken, string apiKey) : base(apiUri, apiToken, apiKey)
        {
        }

        public CreditCardAddCreditCardResponse GenerateToken(string idCustomer, AddCreditCardRequest req)
        {
            return DoPost<AddCreditCardRequest, CreditCardAddCreditCardResponse>(new Uri($"v2/customers/{idCustomer}/fundinginstruments"), req);
        }

        public async Task<CreditCardAddCreditCardResponse> GenerateTokenAsync(string idCustomer, AddCreditCardRequest req)
        {
            return await DoPostAsync<AddCreditCardRequest, CreditCardAddCreditCardResponse>(new Uri($"v2/customers/{idCustomer}/fundinginstruments"), req);
        }

    }
}
