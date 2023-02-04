using Newtonsoft.Json;
using System;

namespace StalcraftSharp.Entities
{
    [JsonObject("EmissionResponse")]
    public class EmissionStatus
    {
        #region Instance Fields
        /// <summary>
        /// The start of the current emission
        /// </summary>
        [JsonProperty("currentStart")]
        public DateTime? CurrentStart { get; set; }

        /// <summary>
        /// The start of the previous emission
        /// </summary>
        [JsonProperty("previousStart")]
        public DateTime? PreviousStart { get; set; }

        /// <summary>
        /// The end of the previous emission
        /// </summary>
        [JsonProperty("previousEnd")]
        public DateTime? PreviousEnd { get; set; }
        #endregion

        #region Constructors
        public EmissionStatus()
        {
            this.CurrentStart = null;
            this.PreviousStart = null;
            this.PreviousEnd = null;
        }
        #endregion
    }
}
