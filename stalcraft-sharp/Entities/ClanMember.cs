using Newtonsoft.Json;
using StalcraftSharp.Enumerations;
using System;

namespace StalcraftSharp.Entities
{
    public class ClanMember
    {
        #region Instance Fields
        /// <summary>
        /// TODO: Unknown.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The character's uuid.
        /// </summary>
        [JsonProperty("rank")]
        public ClanRanks? Rank { get; set; }

        /// <summary>
        /// The character's status.
        /// </summary>
        [JsonProperty("joinTime")]
        public DateTime? JoinTime { get; set; }
        #endregion

        #region Constructors
        public ClanMember()
        {
            this.Name = null;
            this.Rank = null;
            this.JoinTime = null;
        }
        #endregion
    }
}
