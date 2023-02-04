using Newtonsoft.Json;
using System;

namespace StalcraftSharp.Entities
{
    public class LotEntry
    {
        #region Instance Fields
        /// <summary>
        /// The item's id.
        /// </summary>
        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        /// <summary>
        /// The starting price for the lot.
        /// </summary>
        [JsonProperty("startPrice")]
        public long? StartPrice { get; set; }

        /// <summary>
        /// The current price for the lot.
        /// </summary>
        [JsonProperty("currentPrice")]
        public long? CurrentPrice { get; set; }

        /// <summary>
        /// The buyout price for the lot.
        /// </summary>
        [JsonProperty("buyoutPrice")]
        public long? BuyoutPrice { get; set; }

        /// <summary>
        /// The start time of the listing.
        /// </summary>
        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The end time of the listing.
        /// </summary>
        [JsonProperty("endTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Additional data for the listing.
        /// </summary>
        [JsonProperty("additional")]
        public object Additional { get; set; }
        #endregion

        #region Constructors
        public LotEntry()
        {
            this.ItemId = null;
            this.StartPrice = null;
            this.CurrentPrice = null;
            this.BuyoutPrice = null;
            this.StartTime = null;
            this.EndTime = null;
            this.Additional = null;
        }
        #endregion
    }
}
