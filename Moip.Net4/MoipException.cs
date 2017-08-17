using System;
using System.Net;

namespace Moip.Net4
{
    public class MoipException : Exception
    {
        public readonly HttpStatusCode StatusCode;
        
        public MoipException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
