using StalcraftSharp;
using StalcraftSharpTesting.Properties;

namespace StalcraftSharpTesting
{
    public class RegionClientTest
    {
        private RegionClient _client;

        [SetUp]
        public void Setup()
        {
            this._client = new RegionClient(Resources.access_token, bool.Parse(Resources.use_demo_endpoint));
        }

        [Test]
        public async Task GetRegionsAsync()
        {
            var regions = await this._client.GetRegionsAsync();
            Assert.IsTrue(regions.Any(x => x.Id.Equals("NA", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(regions.Any(x => x.Id.Equals("RU", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(regions.Any(x => x.Id.Equals("SEA", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(regions.Any(x => x.Id.Equals("EU", StringComparison.OrdinalIgnoreCase)));
        }
    }
}