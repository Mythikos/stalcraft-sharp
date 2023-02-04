using Newtonsoft.Json;
using System.Collections.Generic;

namespace StalcraftSharp.Entities
{
    public class LotListing
    {
        #region Instance Fields
        /// <summary>
        /// The amount of items.
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; set; }

        /// <summary>
        /// The lot listings.
        /// </summary>
        [JsonProperty("lots")]
        public List<LotEntry> Lots { get; set; }
        #endregion

        #region Constructors
        public LotListing()
        {
            this.Total = null;
            this.Lots = null;
        }
        #endregion
    }
}
