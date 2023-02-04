using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace StalcraftSharp.Core.Protocol
{
    public class HttpClientHandlerToken : HttpClientHandler
    {
        private readonly AuthenticationHeaderValue _authenticationHeader;
        private readonly ProductInfoHeaderValue _productInfoHeader;
        public HttpClientHandlerToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this._authenticationHeader = new AuthenticationHeaderValue("Bearer", accessToken);
            this._productInfoHeader = new ProductInfoHeaderValue("StalcraftSharp", typeof(HttpClientHandlerToken).Assembly.GetName().Version.ToString());
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = this._authenticationHeader;
            request.Headers.UserAgent?.Add(this._productInfoHeader);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
