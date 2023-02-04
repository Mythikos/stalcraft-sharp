using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StalcraftSharp.Core;
using StalcraftSharp.Core.Protocol;
using StalcraftSharp.Entities;
using StalcraftSharp.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using static StalcraftSharp.OAuthClient;

namespace StalcraftSharp
{
    public class OAuthClient : StalcraftClient
    {
        #region Enumeration
        [Flags]
        public enum Scopes
        {
            [EnumMember(Value = "")]
            Nothing = 1,
        }
        #endregion

        #region Instance Variables
        private string _clientId;
        private string _clientSecret;
        private string _redirectUri;

        private const string GRANT_TYPE_AUTHORIZATION_CODE = "authorization_code";
        private const string GRANT_TYPE_REFRESH_TOKEN = "refresh_token";
        #endregion

        #region Constructors
        public OAuthClient(string clientId, string clientSecret, string redirectUri) : base(string.Empty)
        {
            this._clientId = clientId;
            this._clientSecret = clientSecret;
            this._redirectUri = redirectUri;
        }
        #endregion

        public string GetAuthorizationUri(Scopes scopes, string state = null)
        {
            //
            // Build request and snag the uri from it
            var requestBuilder = this.CreateHttpRequest(uri: this.GetOAuthHostURI())
                .AddPath("/oauth/authorize")
                .AddParameter("response_type", "code")
                .AddParameter("client_id", this._clientId)
                .AddParameter("redirect_uri", this._redirectUri)
                .AddParameter("scope", string.Join(" ", Enum.GetValues(scopes.GetType()).Cast<Enum>().Where(x => scopes.HasFlag(x)).Select(x => x.GetAttributeOfType<EnumMemberAttribute>().Value)));

            if (string.IsNullOrWhiteSpace(state) == false)
            {
                requestBuilder.AddParameter("state", state);
            }

            return requestBuilder.ToString();
        }

        public async Task<OAuthTokens> GetAuthorizationTokensAsync(string code)
        {
            OAuthTokens result;

            //
            // Build request
            var requestBuilder = this.CreateHttpRequest(HttpRequestBuilder.HttpMethods.Post, this.GetOAuthHostURI(), HttpRequestBuilder.ParameterModes.Form)
                .AddPath("/oauth/token")
                .AddParameter("client_id", this._clientId)
                .AddParameter("client_secret", this._clientSecret)
                .AddParameter("code", code)
                .AddParameter("grant_type", GRANT_TYPE_AUTHORIZATION_CODE)
                .AddParameter("redirect_uri", this._redirectUri);

            var contentStream = await (await this.SendAsync(requestBuilder.Build())).Content.ReadAsStreamAsync();
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<OAuthTokens>(reader.ReadToEnd());

            return result;
        }

        public async Task<OAuthTokens> RefreshAuthorizationTokenAsync(string refreshToken, Scopes scopes)
        {
            OAuthTokens result;

            //
            // Build request
            var requestBuilder = this.CreateHttpRequest(HttpRequestBuilder.HttpMethods.Post, this.GetOAuthHostURI(), HttpRequestBuilder.ParameterModes.Form)
                .AddPath("/oauth/token")
                .AddParameter("client_id", this._clientId)
                .AddParameter("client_secret", this._clientSecret)
                .AddParameter("grant_type", GRANT_TYPE_REFRESH_TOKEN)
                .AddParameter("refresh_token", refreshToken)
                .AddParameter("scope", string.Join(" ", Enum.GetValues(scopes.GetType()).Cast<Enum>().Where(x => scopes.HasFlag(x)).Select(x => x.GetAttributeOfType<EnumMemberAttribute>().Value)));

            //
            // Make request
            var contentStream = await (await this.SendAsync(requestBuilder.Build())).Content.ReadAsStreamAsync();
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<OAuthTokens>(reader.ReadToEnd());

            return result;
        }
    }
}

