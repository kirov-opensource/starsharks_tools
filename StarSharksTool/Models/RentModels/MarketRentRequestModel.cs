using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Models.RentModels
{
    public class MarketRentRequestModel
    {
        [JsonProperty("class")]
        public List<object> Class { get; set; } = new List<object>();

        [JsonProperty("star")]
        public int Star { get; set; } = 0;

        [JsonProperty("pureness")]
        public int Pureness { get; set; } = 0;

        [JsonProperty("hp")]
        public List<int> Hp { get; set; } = new List<int> { 0, 200 };

        [JsonProperty("speed")]
        public List<int> Speed { get; set; } = new List<int> { 0, 200 };

        [JsonProperty("skill")]
        public List<int> Skill { get; set; } = new List<int> { 0, 200 };

        [JsonProperty("morale")]
        public List<int> Morale { get; set; } = new List<int> { 0, 200 };

        [JsonProperty("body")]
        public List<object> Body { get; set; } = new List<object>();

        [JsonProperty("parts")]
        public List<object> Parts { get; set; } = new List<object>();

        [JsonProperty("rent_cyc")]
        public int RentCyc { get; set; } = 0;

        [JsonProperty("rent_except_gain")]
        public List<int> RentExceptGain { get; set; } = new List<int> { 0, 0 };

        [JsonProperty("skill_id")]
        public List<int> SkillId { get; set; } = new List<int> { 0, 0, 0, 0 };

        [JsonProperty("page")]
        public int Page { get; set; } = 1;

        [JsonProperty("filter")]
        public string Filter { get; set; } = "rent";

        [JsonProperty("sort")]
        public string Sort { get; set; } = "PriceAsc";

        [JsonProperty("page_size")]
        public int PageSize { get; set; } = 36;
    }
}
