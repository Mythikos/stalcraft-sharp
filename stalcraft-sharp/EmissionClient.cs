using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StalcraftSharp.Core;
using StalcraftSharp.Entities;
using System.IO;
using System.Threading.Tasks;

namespace StalcraftSharp
{
    public class EmissionClient : StalcraftClient
    {
        public EmissionClient(string accessToken, bool useDemoEndpoint = false) : base(accessToken, useDemoEndpoint) { }

        public async Task<EmissionStatus> GetEmissionStatusAsync(string region)
        {
            EmissionStatus result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/emission");
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<EmissionStatus>(reader.ReadToEnd());

            return result;
        }
    }
}
