using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StalcraftSharp.Entities
{
    public class Character
    {
        #region Instance Fields
        /// <summary>
        /// The character's username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The character's uuid.
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The character's status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The Character's alliance
        /// </summary>
        [JsonProperty("alliance")]
        public string Alliance { get; set; }

        /// <summary>
        /// The character's creation time.
        /// Note: Only available from the GetCharacters endpoint - https://eapi.stalcraft.net/reference#/paths/region--characters/get.
        /// </summary>
        [JsonProperty("creationTime")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// The character's last login
        /// </summary>
        [JsonProperty("lastLogin")]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// A list of the character's displayed achievements
        /// </summary>
        [JsonProperty("displayedAchievements")]
        public List<string> DisplayedAchievements { get; set; }

        /// <summary>
        /// The character's clan
        /// </summary>
        [JsonProperty("clan")]
        public CharacterClan Clan { get; set; }

        /// <summary>
        /// A list of the character's stats
        /// </summary>
        [JsonProperty("stats")]
        public List<CharacterStat> Stats { get; set; }
        #endregion

        #region Constructors
        public Character()
        {
            this.Username = null;
            this.Uuid = null;
            this.Status = null;
            this.Alliance = null;
            this.CreationTime = null;
            this.LastLogin = null;
            this.DisplayedAchievements = null;
            this.Clan = null;
            this.Stats = null;
        }
        #endregion
    }
}
