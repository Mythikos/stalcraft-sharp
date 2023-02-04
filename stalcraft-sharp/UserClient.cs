using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StalcraftSharp.Core;
using StalcraftSharp.Core.Protocol;
using StalcraftSharp.Entities;
using System;
using System.IO;
using System.Threading.Tasks;
using static StalcraftSharp.OAuthClient;

namespace StalcraftSharp
{
    public class UserClient : StalcraftClient
    {
        public UserClient(string accessToken) : base(accessToken) { }

        public async Task<User> GetUserAsync()
        {
            User result = null;

            //
            // Build request
            var requestBuilder = this.CreateHttpRequest(uri: this.GetOAuthHostURI()).AddPath("/oauth/user");

            //
            // Make request and parse content
            var contentStream = await (await this.SendAsync(requestBuilder.Build())).Content.ReadAsStreamAsync();
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<User>(reader.ReadToEnd());

            return result;
        }
    }
}
