using Newtonsoft.Json;

namespace StalcraftSharp.Entities
{
    public class User
    {
        #region Instance Fields
        /// <summary>
        /// The user's id.
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The user's uuid.
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The login username of the user.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; }

        /// <summary>
        /// Todo: Unknown.
        /// </summary>
        [JsonProperty("display_login")]
        public string DisplayLogin { get; set; }

        /// <summary>
        /// Todo: Unknown.
        /// </summary>
        [JsonProperty("distributor")]
        public string Distributor { get; set; }

        /// <summary>
        /// TODO: Unknown.
        /// </summary>
        [JsonProperty("distributor_id")]
        public string DistributorId { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            this.Id = null;
            this.Uuid = null;
            this.Login = null;
            this.DisplayLogin = null;
            this.Distributor = null;
            this.DistributorId = null;
        }
        #endregion
    }
}
