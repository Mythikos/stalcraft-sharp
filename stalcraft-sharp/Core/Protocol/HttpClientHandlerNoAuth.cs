using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace StalcraftSharp.Core.Protocol
{
    public class HttpClientHandlerNoAuth : HttpClientHandler
    {
        private readonly ProductInfoHeaderValue _productInfoHeader;
        public HttpClientHandlerNoAuth()
        {
            this._productInfoHeader = new ProductInfoHeaderValue("StalcraftSharp", typeof(HttpClientHandlerNoAuth).Assembly.GetName().Version.ToString());
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.UserAgent?.Add(this._productInfoHeader);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
