using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StalcraftSharp.Attributes;
using StalcraftSharp.Core;
using StalcraftSharp.Entities;
using StalcraftSharp.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StalcraftSharp
{
    public class AuctionClient : StalcraftClient
    {
        #region Enumerations
        public enum Order
        {
            [KeyDescriptor("asc")]
            Asc,

            [KeyDescriptor("desc")]
            Desc
        }

        public enum SortBy
        {
            [KeyDescriptor("time_created")]
            TimeCreated,

            [KeyDescriptor("time_left")]
            TimeLeft,

            [KeyDescriptor("current_price")]
            CurrentPrice,

            [KeyDescriptor("buyout_price")]
            BuyoutPrice,
        }
        #endregion

        public AuctionClient(string accessToken, bool useDemoEndpoint = false) : base(accessToken, useDemoEndpoint) { }

        public async Task<PriceListing> GetItemPriceHistoryAsync(string region, string itemId, bool additional = false, int limit = 20, int offset = 0)
        {
            PriceListing result = null;

            //
            // Build parameters
            var parameters = new Dictionary<string, string>();
            parameters.Add("additional", additional.ToString());
            parameters.Add("limit", limit.ToString());
            parameters.Add("offset", offset.ToString());

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/auction/{itemId}/history", parameters);
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<PriceListing>(reader.ReadToEnd());

            return result;
        }

        public async Task<LotListing> GetActiveItemLotsAsync(string region, string itemId, bool additional = false, int limit = 20, int offset = 0, Order orderBy = Order.Asc, SortBy sortBy = SortBy.TimeCreated)
        {
            LotListing result = null;

            //
            // Build parameters
            var parameters = new Dictionary<string, string>();
            parameters.Add("additional", additional.ToString());
            parameters.Add("limit", limit.ToString());
            parameters.Add("offset", offset.ToString());
            parameters.Add("order", orderBy.GetAttributeOfType<KeyDescriptorAttribute>().Key);
            parameters.Add("sort", sortBy.GetAttributeOfType<KeyDescriptorAttribute>().Key);

            //
            // Make request and parse content
            var contentStream = await this.GetAsync($"/{region}/auction/{itemId}/lots", parameters);
            using (var reader = new StreamReader(contentStream))
                result = JsonConvert.DeserializeObject<LotListing>(reader.ReadToEnd());

            return result;
        }
    }
}
