using StalcraftSharp;
using StalcraftSharpTesting.Properties;

namespace StalcraftSharpTesting
{
    public class EmissionClientTest
    {
        private EmissionClient _client;

        [SetUp]
        public void Setup()
        {
            this._client = new EmissionClient(Resources.access_token, bool.Parse(Resources.use_demo_endpoint));
        }

        [Test]
        [TestCase("na")]
        public async Task GetEmissionStatusAsync(string region)
        {
            var emissionStatus = await this._client.GetEmissionStatusAsync(region);
            Assert.IsNotNull(emissionStatus.PreviousStart);
            Assert.IsNotNull(emissionStatus.PreviousEnd);
        }
    }
}