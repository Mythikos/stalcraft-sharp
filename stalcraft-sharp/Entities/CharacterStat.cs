using Newtonsoft.Json;
using StalcraftSharp.Enumerations;

namespace StalcraftSharp.Entities
{
    public class CharacterStat
    {
        #region Instance Fields
        /// <summary>
        /// The stat's id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The stat's type.
        /// </summary>
        [JsonProperty("type")]
        public StatTypes? Type { get; set; }

        /// <summary>
        /// The stat's value.
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }
        #endregion

        #region Constructors
        public CharacterStat()
        {
            this.Id = null;
            this.Type = null;
            this.Value = null;
        }
        #endregion
    }
}
