using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StalcraftSharp.Core.Exceptions
{
    public class StalcraftClientException : Exception
    {
        public StalcraftClientException(HttpRequestMessage request, HttpResponseMessage response) : base(GetMessage(response))
        {
            this.Request = request;
            this.Response = response;
        }

        private static string GetMessage(HttpResponseMessage response)
        {
            return response.ReasonPhrase;
        }

        public HttpRequestMessage Request { get; }
        public HttpResponseMessage Response { get; }
        public HttpStatusCode? Code => this.Response?.StatusCode;

        public async Task<string> GetResponseContentAsStringAsync()
        {
            return await this.Response?.Content?.ReadAsStringAsync();
        }
    }
}
