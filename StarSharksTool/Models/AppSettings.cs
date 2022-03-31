using Newtonsoft.Json;

namespace StarSharksTool.Models
{
    public class AppSettings
    {
        public string? BSC_URL { get; set; } = "https://bsc-dataseed1.binance.org/";
        public string? Proxy { get; set; }
        public List<AccountInfo>? Accounts { get; set; }
        public RentSettings? RENT { get; set; }
        public string? OpenId { get; set; }
    }
    public class RentSettings
    {
        public int? GAS_PRICE { get; set; }
        public int? SEA_PRICE { get; set; }
        public string? MARPLACE_PROXY { get; set; }
    }
}
