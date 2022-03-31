using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Models.RentModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RentResponse
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("nft_address")]
        public string NftAddress { get; set; }

        [JsonProperty("token_owner")]
        public string TokenOwner { get; set; }

        [JsonProperty("token_id")]
        public int TokenId { get; set; }

        [JsonProperty("expire_at")]
        public string ExpireAt { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("rent_cyc")]
        public int RentCyc { get; set; }

        [JsonProperty("inviters")]
        public object Inviters { get; set; }

        [JsonProperty("agents")]
        public object Agents { get; set; }

        [JsonProperty("deadline")]
        public string Deadline { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }

    public class RentModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public RentResponse Data { get; set; }
    }


}
