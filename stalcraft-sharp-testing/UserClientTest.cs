using StalcraftSharp;
using StalcraftSharpTesting.Properties;
using System.Linq;

namespace StalcraftSharpTesting
{
    public class UserClientTest
    {
        private UserClient _client;

        [SetUp]
        public void Setup()
        {
            this._client = new UserClient(Resources.access_token);
        }

        [Test]
        public async Task GetUsersAsync()
        {
            var user = await this._client.GetUserAsync();
            Assert.IsNotNull(user);
            Assert.IsNotNull(user.Id);
            Assert.IsNotNull(user.Uuid);
            Assert.IsNotNull(user.Login);
            Assert.IsTrue(user.Login.Equals("Mythikos", StringComparison.OrdinalIgnoreCase));
        }
    }
}