using Newtonsoft.Json;
using System;

namespace StalcraftSharp.Entities
{
    public class PriceEntry
    {
        #region Instance Fields
        /// <summary>
        /// The amount of items.
        /// </summary>
        [JsonProperty("amount")]
        public long? Amount { get; set; }

        /// <summary>
        /// The price for the lot.
        /// </summary>
        [JsonProperty("price")]
        public long? Price { get; set; }

        /// <summary>
        /// TODO: Unclear
        /// </summary>
        [JsonProperty("time")]
        public DateTime? Time { get; set; }

        /// <summary>
        /// Additional data for the item price.
        /// </summary>
        [JsonProperty("additional")]
        public object Additional { get; set; }
        #endregion

        #region Constructors
        public PriceEntry()
        {
            this.Amount = null;
            this.Price = null;
            this.Time = null;
            this.Additional = null;
        }
        #endregion
    }
}
