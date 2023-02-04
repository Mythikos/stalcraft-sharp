using Newtonsoft.Json;
using System;

namespace StalcraftSharp.Entities
{
    public class ClanInfo
    {
        #region Instance Fields
        /// <summary>
        /// The clan's id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The clan's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The clan's tag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// The level of the clan.
        /// </summary>
        [JsonProperty("level")]
        public int? Level { get; set; }

        /// <summary>
        /// The level points of the clan.
        /// </summary>
        [JsonProperty("levelPoints")]
        public int? LevelPoints { get; set; }

        /// <summary>
        /// The registration time of the clan.
        /// </summary>
        [JsonProperty("registrationTime")]
        public DateTime? RegistrationTime { get; set; }

        /// <summary>
        /// The clan's alliance.
        /// </summary>
        [JsonProperty("alliance")]
        public string Alliance { get; set; }

        /// <summary>
        /// The clan's description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The leader of the clan.
        /// </summary>
        [JsonProperty("leader")]
        public string Leader { get; set; }

        /// <summary>
        /// A count of members in the clan.
        /// </summary>
        [JsonProperty("memberCount")]
        public int? MemberCount { get; set; }
        #endregion

        #region Constructors
        public ClanInfo()
        {
            this.Id = null;
            this.Name = null;
            this.Tag = null;
            this.Level = null;
            this.LevelPoints = null;
            this.RegistrationTime = null;
            this.Alliance = null;
            this.Description = null;
            this.Leader = null;
            this.MemberCount = null;
        }
        #endregion
    }
}
