using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Models.RentModels
{
    public class MarketRentResponseModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Sheet
    {
        [JsonProperty("shark_id")]
        public int SharkId { get; set; }

        [JsonProperty("order_type")]
        public int OrderType { get; set; }

        [JsonProperty("order_status")]
        public int OrderStatus { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("renter")]
        public string Renter { get; set; }

        [JsonProperty("curr_rent_expire_at")]
        public int CurrRentExpireAt { get; set; }

        [JsonProperty("today_gain")]
        public string TodayGain { get; set; }

        [JsonProperty("rent_expire_at")]
        public int RentExpireAt { get; set; }

        [JsonProperty("rent_cyc")]
        public int RentCyc { get; set; }

        [JsonProperty("auto_rent_out")]
        public int AutoRentOut { get; set; }

        [JsonProperty("auto_rent_in")]
        public int AutoRentIn { get; set; }

        [JsonProperty("rent_except_gain")]
        public string RentExceptGain { get; set; }

        [JsonProperty("next_rent_except_gain")]
        public int NextRentExceptGain { get; set; }

        [JsonProperty("sell_price")]
        public int SellPrice { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }

    public class Attr
    {
        [JsonProperty("shark_id")]
        public int SharkId { get; set; }

        [JsonProperty("block_id")]
        public int BlockId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("shark_status")]
        public int SharkStatus { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("restore_at")]
        public int RestoreAt { get; set; }

        [JsonProperty("genes")]
        public string Genes { get; set; }

        [JsonProperty("class")]
        public int Class { get; set; }

        [JsonProperty("stage")]
        public int Stage { get; set; }

        [JsonProperty("star")]
        public int Star { get; set; }

        [JsonProperty("pureness")]
        public int Pureness { get; set; }

        [JsonProperty("hp")]
        public int Hp { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("technic")]
        public int Technic { get; set; }

        [JsonProperty("morale")]
        public int Morale { get; set; }

        [JsonProperty("body")]
        public int Body { get; set; }

        [JsonProperty("head")]
        public int Head { get; set; }

        [JsonProperty("mouth")]
        public int Mouth { get; set; }

        [JsonProperty("neck")]
        public int Neck { get; set; }

        [JsonProperty("dorsal_fin")]
        public int DorsalFin { get; set; }

        [JsonProperty("tail_fin")]
        public int TailFin { get; set; }

        [JsonProperty("ventral_fin")]
        public int VentralFin { get; set; }

        [JsonProperty("skill_1")]
        public int Skill1 { get; set; }

        [JsonProperty("skill_2")]
        public int Skill2 { get; set; }

        [JsonProperty("skill_3")]
        public int Skill3 { get; set; }

        [JsonProperty("skill_4")]
        public int Skill4 { get; set; }

        [JsonProperty("compose_frozen_expired_at")]
        public int ComposeFrozenExpiredAt { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }

    public class GameData
    {
        [JsonProperty("shark_ranking")]
        public int SharkRanking { get; set; }

        [JsonProperty("user_ranking")]
        public int UserRanking { get; set; }

        [JsonProperty("buy_incr")]
        public int BuyIncr { get; set; }
    }

    public class Shark
    {
        [JsonProperty("sheet")]
        public Sheet Sheet { get; set; }

        [JsonProperty("attr")]
        public Attr Attr { get; set; }

        [JsonProperty("game_data")]
        public GameData GameData { get; set; }
    }

    public class Data
    {
        [JsonProperty("sort_by")]
        public string SortBy { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("total_page")]
        public int TotalPage { get; set; }

        [JsonProperty("curr_page")]
        public int CurrPage { get; set; }

        [JsonProperty("sharks")]
        public List<Shark> Sharks { get; set; }
    }
}
