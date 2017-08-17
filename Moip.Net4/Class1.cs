using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace Moip.Net4
{
    public abstract class BaseClient
    {
        #region Properties
        private readonly string ApiToken;
        private readonly string ApiKey;
        private readonly Uri ApiUri;
        private const string UserAgent = "Moip.NET.v0.0.1";
        private readonly Encoding encoding = Encoding.UTF8;
        #endregion

        public BaseClient(Uri apiUri, string apiToken, string apiKey)
        {
            ApiUri = apiUri;
            ApiToken = apiToken;
            ApiKey = apiKey;
        }

        #region JsonSerializerSettings

        protected JsonSerializerSettings JsonSettings { get; }


        public string ToJson(object item)
        {
            return JsonConvert.SerializeObject(item, JsonSettings);

        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, JsonSettings);
        }

        #endregion

        #region DoRequest

        protected virtual HttpClient CreateRequest()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", GetAuthorizationHeader());
            client.DefaultRequestHeaders.Add("ContentType", "application/json");

            return client;
        }

        private string GetAuthorizationHeader()
        {
            var base64Key = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", ApiToken, ApiKey)));
            return string.Format("Basic {0}", base64Key);
        }

        private void TratarRetornoSemSucesso(HttpResponseMessage httpResponse)
        {
            if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                throw new MoipException("APIKey ou Token inválidos.", httpResponse.StatusCode);

            var jsonResult = httpResponse.Content.ReadAsStringAsync().Result;

            var responseError = FromJson<ResponseError>(jsonResult);
            throw new MoipException(responseError.FullMessage, httpResponse.StatusCode);
        }

        #region POST
        protected async Task<HttpResponseMessage> DoPostVoidAsync<REQ>(Uri uri, REQ body)
        {
            HttpClient req = CreateRequest();
            try
            {
                HttpContent abodyEnvio = new StringContent(ToJson(body));
                var retorno = await req.PostAsync(uri, abodyEnvio);
                if (!retorno.IsSuccessStatusCode)
                    TratarRetornoSemSucesso(retorno);

                return retorno;
            }
            catch (Exception exception)
            {
                throw;
            }
        }


        protected async Task<RES> DoPostAsync<REQ, RES>(Uri uri, REQ body)
        {

            try
            {
                var retorno = await DoPostVoidAsync(uri, body);

                var retornoJson = await retorno.Content.ReadAsStringAsync();
                return FromJson<RES>(retornoJson);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        protected RES DoPost<REQ, RES>(Uri uri, REQ body)
        {
            return DoPostAsync<REQ, RES>(uri, body).Result;
        }

        protected HttpResponseMessage DoPostVoid<REQ>(Uri uri, REQ body)
        {
            return DoPostVoidAsync(uri, body).Result;
        }

        #endregion



        #region GET
        protected async Task<RES> DoGetAsync<RES>(Uri uri)
        {
            HttpClient req = CreateRequest();

            try
            {
                var retorno = await req.GetAsync(uri);
                if (!retorno.IsSuccessStatusCode)
                    TratarRetornoSemSucesso(retorno);

                var retornoJson = await retorno.Content.ReadAsStringAsync();
                return FromJson<RES>(retornoJson);
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        protected RES DoGet<RES>(Uri uri)
        {
            return DoGetAsync<RES>(uri).Result;
        }
        #endregion

        #region DELETE
        protected async Task<HttpResponseMessage> DoDeleteAsync(Uri uri)
        {
            HttpClient req = CreateRequest();

            try
            {
                var retorno = await req.GetAsync(uri);
                if (!retorno.IsSuccessStatusCode)
                    TratarRetornoSemSucesso(retorno);
                
                return retorno;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        protected HttpResponseMessage DoDelete(Uri uri)
        {
            return DoDeleteAsync(uri).Result;
        }
        #endregion





        protected virtual Uri PathToUri(string path, string query = null)
        {
            UriBuilder uriBuilder = new UriBuilder(ApiUri);
            uriBuilder.Path = path;
            if (!string.IsNullOrEmpty(query))
            {
                uriBuilder.Query = query;
            }
            return uriBuilder.Uri;
        }

        #endregion

    }


    public class ResponseDetail
    {
        /// <summary>
        /// Descrição do alerta
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Código do alerta
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Parâmetro relacionado ao erro (Apenas V2)
        /// </summary>
        public string Path { get; set; }
    }

    /// <summary>
    /// Estrutura de retorno de mensagens do Moip
    /// </summary>
    public struct ResponseError
    {
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Erros da mensagem, se existirem
        /// </summary>
        public ResponseDetail[] Errors { get; set; }


        public string FullMessage
        {
            get
            {
                var msg = "";
                if (!string.IsNullOrEmpty(Message))
                {
                    msg += Message + (Errors.Length > 0 ? Environment.NewLine : "");
                }

                msg += string.Join(Environment.NewLine, Errors.Select(x => x.Description).ToArray());

                return msg;
            }
        }

    }


}
