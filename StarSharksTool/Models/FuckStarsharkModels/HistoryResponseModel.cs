using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Models.FuckStarsharkModels
{
    public class HistoryDetail
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("number")]
        public object Number { get; set; }

        [JsonProperty("diff")]
        public object Diff { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("err")]
        public string Err { get; set; }

        [JsonProperty("dayPrize")]
        public string DayPrize { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("extract")]
        public object Extract { get; set; }

        [JsonProperty("Time")]
        public string Time { get; set; }

        [JsonProperty("Bearer")]
        public string Bearer { get; set; }
    }

    public class HistoryResponseModel
    {
        [JsonProperty("state")]
        public bool State { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("data")]
        public List<HistoryDetail> Data { get; set; }
    }
}
