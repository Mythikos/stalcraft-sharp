using StalcraftSharp;
using StalcraftSharpTesting.Properties;

namespace StalcraftSharpTesting
{
    public class ClanClientTest
    {
        private ClanClient _client;

        [SetUp]
        public void Setup()
        {
            this._client = new ClanClient(Resources.access_token, bool.Parse(Resources.use_demo_endpoint));
        }

        [Test]
        [TestCase("na")]
        public async Task GetClanListAsync(string region)
        {
            var clans = await this._client.GetClanListAsync(region);
            Assert.IsNotNull(clans);
            Assert.IsTrue(clans.Count > 0);
        }

        [Test]
        [TestCase("na", "647d6c53-b3d7-4d30-8d08-de874eb1d845")]
        public async Task GetClanInfo(string region, string clanId)
        {
            var clanInfo = await this._client.GetClanInfoAsync(region, clanId);
            Assert.IsNotNull(clanInfo);
            Assert.IsNotNull(clanInfo.Id);
            Assert.IsNotNull(clanInfo.Name);
        }

        [Test]
        [TestCase("na", "647d6c53-b3d7-4d30-8d08-de874eb1d845")]
        public async Task GetClanMembersAsync(string region, string clanId)
        {
            var clanMembers = await this._client.GetClanMembersAsync(region, clanId);
            Assert.IsNotNull(clanMembers);
            Assert.IsTrue(clanMembers.Count > 0);
        }
    }
}