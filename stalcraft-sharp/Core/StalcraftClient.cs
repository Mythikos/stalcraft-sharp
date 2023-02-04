using StalcraftSharp.Core.Exceptions;
using StalcraftSharp.Core.Protocol;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using static StalcraftSharp.Core.Protocol.HttpRequestBuilder;

namespace StalcraftSharp.Core
{
    public abstract class StalcraftClient
    {
        #region Instance Variables
        private readonly string _accessToken;
        private readonly bool _useDemoEndpoint;
        
        public const string URI_OAUTH_PRODUCTION_HOST = @"https://exbo.net";
        public const string URI_API_DEMO_HOST = @"https://dapi.stalcraft.net";
        public const string URI_API_PRODUCTION_HOST = @"https://eapi.stalcraft.net";
        #endregion

        #region Constructors
        protected StalcraftClient()
        {
            this._accessToken = string.Empty;
            this._useDemoEndpoint = false;
        }

        protected StalcraftClient(string accessToken, bool useDemoEndpoint = false)
        {
            this._accessToken = accessToken;
            this._useDemoEndpoint = useDemoEndpoint;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Used to send an http request, verify success, and return the response.
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        /// <exception cref="StalcraftClientException"></exception>
        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest)
        {
            using (var httpClient = this.CreateHttpClient())
            {
                var httpResponse = await httpClient.SendAsync(httpRequest);
                if (httpResponse.IsSuccessStatusCode == false)
                {
                    throw new StalcraftClientException(httpRequest, httpResponse);
                }

                return httpResponse;
            }
        }

        /// <summary>
        /// Helper method to perform GET against API endpoint with given parameters.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task<Stream> GetAsync(string path, Dictionary<string, string> parameters = null)
        {
            Stream result = null;

            var requestBuilder = this.CreateHttpRequest(HttpRequestBuilder.HttpMethods.Get, this.GetAPIHostURI(), ParameterModes.Query).AddPath(path);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    requestBuilder.AddParameter(parameter);
                }
            }

            var httpRequest = requestBuilder.Build();
            var httpResponse = await this.SendAsync(httpRequest);
            if (httpResponse.Content.Headers.ContentLength.HasValue && httpResponse.Content.Headers.ContentLength == 0)
            {
                result = Stream.Null;
            }
            else
            {
                result = await httpResponse.Content.ReadAsStreamAsync();
            }

            return result;
        }

        /// <summary>
        /// Helper method to perform POST against API endpoint with given parameters.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task<Stream> PostAsync(string path, Dictionary<string, string> parameters = null)
        {
            Stream result = null;

            var requestBuilder = this.CreateHttpRequest(HttpRequestBuilder.HttpMethods.Post, this.GetAPIHostURI(), ParameterModes.Form).AddPath(path);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    requestBuilder.AddParameter(parameter);
                }
            }

            var httpRequest = requestBuilder.Build();
            var httpResponse = await this.SendAsync(httpRequest);
            if (httpResponse.Content.Headers.ContentLength.HasValue && httpResponse.Content.Headers.ContentLength == 0)
            {
                result = Stream.Null;
            }
            else
            {
                result = await httpResponse.Content.ReadAsStreamAsync();
            }

            return result;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Helper method for instantiating a new HttpRequestBuilder.
        /// </summary>
        /// <param name="httpMethod"></param>
        /// <param name="uri"></param>
        /// <param name="parameterMode"></param>
        /// <returns></returns>
        protected HttpRequestBuilder CreateHttpRequest(HttpMethods httpMethod = HttpMethods.Get, string uri = null, ParameterModes parameterMode = ParameterModes.Query)
        {
            return new HttpRequestBuilder(httpMethod, uri, parameterMode);
        }

        /// <summary>
        /// Helper method for instantiating a new HttpClient.
        /// </summary>
        /// <returns></returns>
        private HttpClient CreateHttpClient()
        {
            return new HttpClient(this.CreateHttpHandler());
        }

        /// <summary>
        /// Helper method for instantiating a new HttpClientHandler.
        /// </summary>
        /// <returns></returns>
        private HttpClientHandler CreateHttpHandler()
        {
            if (string.IsNullOrWhiteSpace(this._accessToken) == false)
            {
                return new HttpClientHandlerToken(this._accessToken);
            }
            else
            {
                return new HttpClientHandlerNoAuth();
            }
        }

        /// <summary>
        /// Returns the applicable API Host URI.
        /// </summary>
        /// <returns></returns>
        public string GetAPIHostURI()
            => this._useDemoEndpoint ? URI_API_DEMO_HOST : URI_API_PRODUCTION_HOST;

        /// <summary>
        /// Returns the applicable OAuth Host URI.
        /// </summary>
        /// <returns></returns>
        public string GetOAuthHostURI()
            => URI_OAUTH_PRODUCTION_HOST;
        #endregion
    }
}
