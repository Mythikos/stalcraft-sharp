using Newtonsoft.Json;

namespace StalcraftSharp.Entities
{
    public class CharacterClan
    {
        #region Instance Fields
        /// <summary>
        /// The clan's information.
        /// </summary>
        [JsonProperty("info")]
        public ClanInfo Info { get; set; }

        /// <summary>
        /// Member information.
        /// </summary>
        [JsonProperty("member")]
        public ClanMember Member { get; set; }
        #endregion

        #region Constructors
        public CharacterClan()
        {
            this.Info = null;
            this.Member = null;
        }
        #endregion
    }
}
