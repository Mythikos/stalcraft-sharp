using StalcraftSharp;
using StalcraftSharpTesting.Properties;

namespace StalcraftSharpTesting
{
    public class CharacterClientTest
    {
        private CharacterClient _client;

        [SetUp]
        public void Setup()
        {
            this._client = new CharacterClient(Resources.access_token, bool.Parse(Resources.use_demo_endpoint));
        }

        [Test]
        [TestCase("na")]
        public async Task GetCharacterAsync(string region)
        {
            var characters = await this._client.GetCharactersAsync(region);
            Assert.IsNotNull(characters);
            Assert.IsTrue(characters.Count > 0);
        }

        [Test]
        [TestCase("na", "Mythikos")]
        public async Task GetCharacterByNameAsync(string region, string characterName)
        {
            var character = await this._client.GetCharacterByNameAsync(region, characterName);
            Assert.IsNotNull(character);
            //Assert.IsNotNull(character.Clan);
            Assert.IsNotNull(character.Stats);
            Assert.IsTrue(character.Username.Equals(characterName));
            Assert.IsTrue(character.Stats.Count > 0);
        }

        [Test]
        [TestCase("na", "Test-1")]
        public async Task GetCharacterFriendsAsync(string region, string characterName)
        {
            var characterFriends = await this._client.GetCharacterFriendsAsync(region, characterName);
            Assert.IsNotNull(characterFriends);
            Assert.IsTrue(characterFriends.Count > 0);
        }
    }
}