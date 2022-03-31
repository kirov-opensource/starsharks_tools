using Microsoft.Extensions.Caching.Distributed;
using StarSharksTool.Models;
using System.Net;

namespace StarSharksTool
{
    public static class Global
    {
        //public static Dictionary<string, AccountModel> Accounts = new Dictionary<string, AccountModel>() {
        //    {"A1",new AccountModel{ } },
        //    {"A2",new AccountModel{ } },
        //    {"A3",new AccountModel{ } },
        //    {"A4",new AccountModel{ } }
        //};
        internal static Dictionary<int, decimal> DynamicGASPrice = new Dictionary<int, decimal>();
        internal static decimal GetGasPrice(int seaPrice)
        {
            if (DynamicGASPrice == null)
                return 6;
            if (!DynamicGASPrice.ContainsKey(seaPrice))
            {
                return 6;
            }
            return (DynamicGASPrice[seaPrice] + 0.001m);
        }
        internal static List<AccountModel> Accounts { get; set; } = new List<AccountModel>();

        internal const string SETTING_PATH = "./AppSettings.json";

        internal static string SNFT_ADDRESS = "0x416f1D70c1C22608814d9f36c492EfB3Ba8cad4c";
        internal static string SEA_ADDRESS = "0x26193C7fa4354AE49eC53eA2cEBC513dc39A10aa";
        internal static string SSS_ADDRESS = "0xC3028FbC1742a16A5D69dE1B334cbce28f5d7EB3";
        internal static string RENT_CONTRACT_ADDRESS = "0xe9e092e46a75d192d9d7d3942f11f116fd2f7ca9";
        internal static string BUY_CONTRACT_ADDRESS = "0x1f7acc330fe462a9468aa47ecdb543787577e1e7";
        internal static string WITHDRAW_CONTRACT_ADDRESS = "0x94019518f82762bb94280211d19d4ac025d98583";
        internal static string WITHDRAW_CONTRACT_ADDRESS_V2 = "0x4A7634c4dd3AE3e3e72f09089807Db2f04746741";
        internal static string KeyHash = "";

        internal static string? PROXY { get; set; }

        internal static string BSC_URL = "";

        internal static Nethereum.Web3.Web3 Web3;

        internal static AppSettings AppSettings { get; set; }

        private static HttpClient _httpClient { get; set; }

        internal static HttpClient GetClient(string proxy)
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            if (!string.IsNullOrWhiteSpace(PROXY))
            {
                clientHandler.UseProxy = true;
                clientHandler.Proxy = new WebProxy(PROXY);
            }
            _httpClient = new HttpClient(clientHandler);
            return _httpClient;
        }

        internal static HttpClient HTTPCLIENT
        {
            get
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                if (!string.IsNullOrWhiteSpace(PROXY))
                {
                    clientHandler.UseProxy = true;
                    clientHandler.Proxy = new WebProxy(PROXY);
                }
                _httpClient = new HttpClient(clientHandler);
                return _httpClient;
            }
            set
            {
                _httpClient = value;
            }
        }

        public static IDistributedCache? Cache { get; internal set; }
    }
}
