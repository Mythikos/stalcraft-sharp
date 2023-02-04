using Newtonsoft.Json;

namespace StalcraftSharp.Entities
{
    [JsonObject("RegionInfo")]
    public class Region
    {
        #region Instance Fields
        /// <summary>
        /// The region's id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The region's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion

        #region Constructors
        public Region()
        {
            this.Id = null;
            this.Name = null;
        }
        #endregion
    }
}
