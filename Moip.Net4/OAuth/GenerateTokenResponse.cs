﻿using System.Linq;
using System.Text;

namespace Moip.Net4.OAuth
{

    public class GenerateTokenResponse
    {
        public string Access_token { get; set; }
        public string Expires_in { get; set; }
        public string Refresh_token { get; set; }
        public string Scope { get; set; }
    }
}
