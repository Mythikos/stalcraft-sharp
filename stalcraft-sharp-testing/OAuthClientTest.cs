using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using StalcraftSharp;
using StalcraftSharp.Entities;
using StalcraftSharpTesting.Properties;

namespace StalcraftSharpTesting
{
    public class OAuthClientTest
    {
        private OAuthClient _client;


        [SetUp]
        public void Setup()
        {
            this._client = new OAuthClient(Resources.oauth_client_id, Resources.oauth_client_secret, "http://localhost");
        }

        [Test, Order(1)]
        public void GetAuthorizationUri()
        {
            var authorizationUri = this._client.GetAuthorizationUri(OAuthClient.Scopes.Nothing);
            Assert.IsTrue(authorizationUri.StartsWith(this._client.GetOAuthHostURI()));
            Assert.IsTrue(authorizationUri.Contains(Resources.oauth_client_id));
            Assert.IsTrue(authorizationUri.Contains("client_id="));
            Assert.IsTrue(authorizationUri.Contains("redirect_uri="));
            Assert.IsTrue(authorizationUri.Contains("scope="));
            Assert.IsTrue(authorizationUri.Contains("response_type="));
        }

        [Test, Order(2)]
        [TestCase("")]
        public async Task GetAuthorizationTokensAsync(string code)
        {
            var tokens = await this._client.GetAuthorizationTokensAsync(code);
            Assert.IsNotNull(tokens.AccessToken);
            Assert.IsNotNull(tokens.RefreshToken);
            Assert.IsTrue(tokens.TokenType.Equals("Bearer"));
            Assert.IsNotNull(tokens.ExpiresIn);
        }

        [Test, Order(3)]
        [TestCase("")]
        public async Task RefreshAuthorizationTokensAsync(string refreshToken)
        {
            var tokens = await this._client.RefreshAuthorizationTokenAsync(refreshToken, OAuthClient.Scopes.Nothing);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokens.AccessToken));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tokens.RefreshToken));
            Assert.IsTrue(tokens.TokenType.Equals("Bearer"));
            Assert.IsNotNull(tokens.ExpiresIn);
        }
    }
}