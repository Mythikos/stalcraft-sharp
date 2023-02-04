using Newtonsoft.Json;
using System;

namespace StalcraftSharp.Entities
{
    public class OAuthTokens
    {
        #region Instance Variables
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        [JsonProperty("expires_in")]
        public int? ExpiresIn { get; private set; }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        public DateTime? ExpiresAt { get; private set; }
        #endregion

        public OAuthTokens(string accessToken, string refreshToken, int? expiresIn, string tokenType)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.ExpiresIn = expiresIn;
            this.TokenType = tokenType;
            if (this.ExpiresIn != null)
            {
                this.ExpiresAt = DateTime.Now.AddSeconds(this.ExpiresIn.Value);
            }
        }
    }
}
