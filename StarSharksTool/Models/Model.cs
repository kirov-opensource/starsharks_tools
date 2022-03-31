using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using StarSharksTool.Enums;
using System.ComponentModel;

namespace StarSharksTool.Models
{
    internal class Model
    {
    }
    public class AccountModel
    {
        public Account? Account { get; set; }

        public string WebsiteToken { get; set; }

        public string Alias { get; set; }

        public string GameToken { get; set; }

        public AccountInfoModel AccountInfo { get; set; }

        public Dictionary<int, SharkModel> Sharks { get; set; }
    }

    public class QuerySharksModel
    {
        [JsonProperty("tag_type")]
        public int TagType { get; set; }

        [JsonProperty("page")]
        public int PageNo { get; set; } = 1;

        [JsonProperty("page_size")]
        public int PageSize { get; set; } = 1000;
    }

    public class ResponseModel<T>
    {
        [JsonProperty("data")]
        public T? Data { get; set; }
    }

    public class PagenationModel<T>
    {
        [JsonProperty("sharks")]
        public IList<T>? Sharks { get; set; }
    }

    public class SharkModel
    {
        public string AccountAddress { get; set; }

        [JsonProperty("sheet")]
        public Sheet Sheet { get; set; }

        [JsonProperty("attr")]
        public Attr Attr { get; set; }

        [JsonProperty("game_data")]
        public GameData GameData { get; set; }

        public SharkStatus SharkStatus
        {
            get
            {
                if (Attr.SharkStatus == 21)
                {
                    if (Sheet.Renter.Equals(AccountAddress, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return SharkStatus.RentIn;
                    }
                    return SharkStatus.RentOut;
                }
                else if (Attr.SharkStatus == 1 || Attr.SharkStatus == 31)
                {
                    return SharkStatus.Normal;
                }
                return SharkStatus.Unknown;

            }
        }
        public string SharkStatusDisplay
        {
            get
            {
                var fieldInfo = SharkStatus.GetType().GetField(SharkStatus.ToString());

                var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : SharkStatus.ToString();
            }
        }
        public string SharkInfo
        {
            get
            {
                if (Attr.SharkStatus == 21)
                {
                    var offset = (DateTimeOffset.FromUnixTimeSeconds(Sheet.RentExpireAt) - DateTime.Now);
                    var t = DateTime.Today.Add(offset).ToString("HH:mm:ss");
                    return Attr.SharkId.ToString() + "\t" + String.Empty.PadLeft(Attr.Star, '★').PadLeft(5, '　') + $"\n{Attr.Power}/{Attr.Star * 10}\t{SharkStatusDisplay}\t{t}";
                }
                var restoreOffset = (DateTimeOffset.FromUnixTimeSeconds(Attr.RestoreAt) - DateTime.Now);
                return Attr.SharkId.ToString() + "\t" + String.Empty.PadLeft(Attr.Star, '★').PadLeft(5, '　') + $"\n{Attr.Power}/{Attr.Star * 10}\t{SharkStatusDisplay}\t恢复体力剩余:{restoreOffset.TotalMinutes.ToString("0.00")}分钟";
            }
        }
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
        public decimal SellPrice { get; set; }

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
    #region Account
    public class RandomStringModel
    {
        [JsonProperty("message")]
        public string? RandomString { get; set; }
    }

    public class LoginResponseModel
    {
        [JsonProperty("authorization")]
        public string? Authorization { get; set; }

        [JsonProperty("new_created")]
        public bool NewCreated { get; set; }

        [JsonProperty("qr_code")]
        public string? QRCode { get; set; }
    }

    public class LoginRequestModel
    {
        [JsonProperty("account")]
        public string? Address { get; set; }

        [JsonProperty("hexsign")]
        public string? Sign { get; set; }

        [JsonProperty("message")]
        public string? RandomString { get; set; }
    }

    public class AccountInfoModel
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
    #endregion
}
