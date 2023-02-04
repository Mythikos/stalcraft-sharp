using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StalcraftSharp.Core;
using StalcraftSharp.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StalcraftSharp
{
    public class ClanClient : StalcraftClient
    {
        public ClanClient(string accessToken, bool useDemoEndpoint = false) : base(accessToken, useDemoEndpoint) { }

        public async Task<ClanInfo> GetClanInfoAsync(string region, string clanId)
        {
            ClanInfo result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/clan/{clanId}/info");
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<ClanInfo>(reader.ReadToEnd());

            return result;
        }

        public async Task<List<ClanMember>> GetClanMembersAsync(string region, string clanId)
        {
            List<ClanMember> result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/clan/{clanId}/members");
            using (var reader = new StreamReader(contentStream))
            {
                result = JsonConvert.DeserializeObject<List<ClanMember>>(reader.ReadToEnd());
            }

            return result;
        }

        public async Task<List<ClanInfo>> GetClanListAsync(string region, int limit = 20, int offset = 0)
        {
            List<ClanInfo> result = null;

            //
            // Build parameters
            var parameters = new Dictionary<string, string>();
            parameters.Add("limit", limit.ToString());
            parameters.Add("offset", offset.ToString());

            //
            // Make request
            var contentStream = await this.GetAsync($"/{region}/clans", parameters);
            using (var reader = new StreamReader(contentStream))
            {
                var jsonObject = JObject.Parse(reader.ReadToEnd());

                // Build our result
                result = new List<ClanInfo>();
                foreach (var token in jsonObject.SelectToken("data"))
                    result.Add(JsonConvert.DeserializeObject<ClanInfo>(token.ToString()));
            }

            return result;
        }
    }
}
