using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StalcraftSharp.Core;
using StalcraftSharp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StalcraftSharp
{
    public class CharacterClient : StalcraftClient
    {
        public CharacterClient(string accessToken, bool useDemoEndpoint = false) : base(accessToken, useDemoEndpoint) { }

        public async Task<Character> GetCharacterByNameAsync(string region, string character)
        {
            Character result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/character/by-name/{character}/profile");
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<Character>(reader.ReadToEnd());

            return result;
        }

        public async Task<List<Character>> GetCharactersAsync(string region)
        {
            List<Character> result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/characters");
            using (var reader = new StreamReader(contentStream))
            {
                var jsonArray = JArray.Parse(reader.ReadToEnd());

                // Build our result
                result = new List<Character>();
                foreach (var token in jsonArray)
                {
                    var character = new Character();
                    character.Username = token.SelectToken("information.name").ToString();
                    character.Uuid = token.SelectToken("information.id").ToString();
                    character.CreationTime = token.SelectToken("information.creationTime").ToObject<DateTime>();
                    character.Clan = token.SelectToken("clan").ToObject<CharacterClan>();
                    result.Add(character);

                }
            }

            return result;
        }

        public async Task<List<string>> GetCharacterFriendsAsync(string region, string character)
        {
            List<string> result = null;

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/friends/{character}");
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<List<string>>(reader.ReadToEnd());

            return result;
        }
    }
}
