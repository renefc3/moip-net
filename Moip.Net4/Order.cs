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


    }
}
