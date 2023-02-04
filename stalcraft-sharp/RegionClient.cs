using Newtonsoft.Json;
using StalcraftSharp.Core;
using StalcraftSharp.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StalcraftSharp
{
    public class RegionClient : StalcraftClient
    {
        public RegionClient(string accessToken, bool useDemoEndpoint = false) : base(accessToken, useDemoEndpoint) { }

        public async Task<List<Region>> GetRegionsAsync()
        {
            List<Region> result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync("/regions");
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<List<Region>>(reader.ReadToEnd());

            return result;
        }


    }
}
