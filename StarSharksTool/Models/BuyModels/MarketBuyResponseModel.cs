using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Models.BuyModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MarketBuyResponseModel
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("nft_address")]
        public string NftAddress { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("shark_id")]
        public int SharkId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("inviters")]
        public object Inviters { get; set; }

        [JsonProperty("agents")]
        public object Agents { get; set; }

        [JsonProperty("deadline")]
        public string Deadline { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
    public class BuyModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public MarketBuyResponseModel Data { get; set; }
    }

}
