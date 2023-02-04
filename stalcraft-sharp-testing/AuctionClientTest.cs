using StalcraftSharp;
using StalcraftSharpTesting.Properties;

namespace StalcraftSharpTesting
{
    public class AuctionClientTest
    {
        private AuctionClient _client;

        [SetUp]
        public void Setup()
        {
            this._client = new AuctionClient(Resources.access_token, bool.Parse(Resources.use_demo_endpoint));
        }

        [Test]
        [TestCase("na", "0QKe")]
        public async Task GetLotPriceHistoryAsync(string region, string item)
        {
            var priceListing = await this._client.GetItemPriceHistoryAsync(region, item, true);
            Assert.IsNotNull(priceListing);
            Assert.IsNotNull(priceListing.Prices);
            Assert.IsTrue(priceListing.Prices.Count > 0);
        }

        [Test]
        [TestCase("na", "0QKe")]
        public async Task GetActiveLotsAsync(string region, string item)
        {
            var lotListing = await this._client.GetActiveItemLotsAsync(region, item, true);
            Assert.IsNotNull(lotListing);
            Assert.IsNotNull(lotListing.Lots);
            Assert.IsTrue(lotListing.Lots.Count > 0);
        }
    }
}