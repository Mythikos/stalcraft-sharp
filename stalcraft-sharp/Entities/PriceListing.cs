using Newtonsoft.Json;
using System.Collections.Generic;

namespace StalcraftSharp.Entities
{
    public class PriceListing
    {
        #region Instance Fields
        /// <summary>
        /// The amount of items.
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; set; }

        /// <summary>
        /// The the lot history.
        /// </summary>
        [JsonProperty("prices")]
        public List<PriceEntry> Prices { get; set; }
        #endregion

        #region Constructors
        public PriceListing()
        {
            this.Total = null;
            this.Prices = null;
        }
        #endregion
    }
}
