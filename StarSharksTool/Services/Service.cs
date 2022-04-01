using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using RestSharp;
using StarSharksTool.Contracts.ERC721;
using StarSharksTool.Models;
using StarSharksTool.Models.BuyModels;
using StarSharksTool.Models.FuckStarsharkModels;
using StarSharksTool.Models.JSONRPCModels;
using StarSharksTool.Models.RentModels;
using StarSharksTool.Models.SharkDetailModels;
using StarSharksTool.Models.WithdrawModels;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

namespace StarSharksTool.Services
{
    internal class Service
    {
        public static int step = 0;
        internal event EventHandler<TransferEventArgs>? TransferEvent;
        public static HashSet<int> RentedSharkIds = new HashSet<int>();
        private void OnTransferEvent(TransferEventArgs messageEventArgs)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<TransferEventArgs>? transferEvent = TransferEvent;

            // Event will be null if there are no subscribers
            if (transferEvent != null)
            {
                // Call to raise the event.
                transferEvent(this, messageEventArgs);
            }
        }

        internal async Task TransferSharks(IEnumerable<TransferRecord> transferRecords)
        {
            try
            {
                var groups = transferRecords.GroupBy(x => x.From);

                foreach (var group in groups)
                {
                    var accountModel = Global.Accounts.FirstOrDefault(x => x.Account?.Address == group.Key);
                    if (accountModel == null)
                    {
                        group.ToList().ForEach(x =>
                        {
                            OnTransferEvent(new TransferEventArgs
                            {
                                From = x.From,
                                Successful = false,
                                To = x.To,
                                TokenId = x.TokenId
                            });
                        });
                        continue;
                    }

                    var web3 = new Web3(accountModel.Account, Global.BSC_URL);
                    web3.TransactionManager.UseLegacyAsDefault = true;
                    var contractHandler = web3.Eth.GetContractHandler(Global.SNFT_ADDRESS);
                    foreach (var transferRecord in group)
                    {
                        try
                        {
                            var transferFromFunction = new TransferFromFunction();
                            transferFromFunction.From = transferRecord!.From!;
                            transferFromFunction.To = transferRecord!.To!;
                            transferFromFunction.TokenId = transferRecord!.TokenId!;
                            var transferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction).ConfigureAwait(false);
                            OnTransferEvent(new TransferEventArgs
                            {
                                From = transferRecord!.From!,
                                Successful = transferFromFunctionTxnReceipt.Status == new Nethereum.Hex.HexTypes.HexBigInteger("1"),
                                To = transferRecord!.To!,
                                TokenId = transferRecord!.TokenId!
                            });
                        }
                        catch (Exception ex1)
                        {
                            Global.GetLogger("Service").LogError(ex1, ex1.Message);
                            try
                            {
                                OnTransferEvent(new TransferEventArgs
                                {
                                    From = transferRecord!.From!,
                                    Successful = false,
                                    To = transferRecord!.To!,
                                    TokenId = transferRecord!.TokenId!
                                });
                            }
                            catch (Exception ex2)
                            {
                                Global.GetLogger("Service").LogError(ex2, ex2.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex){

                Global.GetLogger("SharkManagement").LogError(ex, ex.Message);
                throw ex;
            }
        }
        public static string FillZero(string hexValue, int targetLength = 64)
        {
            var value = hexValue;
            if (hexValue.StartsWith("0x"))
            {
                value = hexValue[2..];
            }
            return value.PadLeft(targetLength, '0');
        }
        public static string RFillZero(string hexValue, int targetLength = 64)
        {
            var value = hexValue;
            if (hexValue.StartsWith("0x"))
            {
                value = hexValue[2..];
            }
            return value.PadRight(targetLength, '0');
        }
        internal async static Task<MarketRentResponseModel> GetMarketplace(int maxPrice, int level, string proxy)
        {
            try
            {
                var url = "https://www.starsharks.com/go/api/market/sharks";
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                //httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", account.JWTToken);
                var req = new MarketRentRequestModel();
                step++;
                if (step >= 50) step = 0;
                Random r = new Random();
                req.Morale = new List<int> { 1, 100 + r.Next(1, 50) };
                req.Hp = new List<int> { 1, 100 + r.Next(1, 50) };
                req.Speed = new List<int> { 1, 100 + r.Next(1, 50) };
                req.RentExceptGain = new List<int> { 1, 13 + step + maxPrice };
                req.Star = level;

                if (step % 2 == 0)
                {
                    req.Page = 2;
                }

                if (step % 4 == 0)
                {
                    req.Sort = "LatestDesc";
                }

                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
                var client = Global.GetClient(proxy);
                {
                    var httpResponse = await client.SendAsync(httpRequestMessage);
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        Global.GetLogger("Service").LogError($"{url} 失败: {content}");
                        return new MarketRentResponseModel { Data = new Models.RentModels.Data { Sharks = new List<Shark> { } } };
                    }
                    var responseModel = JsonConvert.DeserializeObject<MarketRentResponseModel>(content);
                    if (responseModel?.Data?.Sharks?.Any() ?? false)
                    {
                        responseModel.Data.Sharks = responseModel.Data.Sharks.Where(c =>
                        {
                            var price = (int)double.Parse(c.Sheet.RentExceptGain);
                            return maxPrice >= price;
                        }).ToList();
                    }
                    return responseModel;
                }
            }
            catch(Exception e)
            {
                Global.GetLogger("Service").LogError(e, e.Message);
                return new MarketRentResponseModel { Data = new Models.RentModels.Data { Sharks = new List<Shark> { } } };
            }
        }
        internal async static Task<WithdrawResponseModel> GetSharkWithdrawInfo(AccountModel account)
        {
            var url = "https://www.starsharks.com/go/auth-api/account/withdraw-sea-v2";
            var sharkResp = new WithdrawResponseModel();
            //Global.HTTPCLIENT
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", account.WebsiteToken);
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(new { }), Encoding.UTF8, "application/json");
            var client = Global.HTTPCLIENT;
            {
                var httpResponse = await client.SendAsync(httpRequestMessage);
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    Global.GetLogger("Service").LogError($"{url} 失败: {content}");
                    //throw new HttpRequestException();
                    return await GetSharkWithdrawInfo(account);
                }
                var responseModel = JsonConvert.DeserializeObject<WithdrawResponseModel>(content);
                return responseModel;
            }
        }
        internal async static Task<RentModel> GetSharkRentInfo(AccountModel account, int sharkId)
        {
            var sharkResp = new RentModel();
            //Global.HTTPCLIENT
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://www.starsharks.com/go/auth-api/market/rent-in");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", account.WebsiteToken);
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(new { shark_id = sharkId }), Encoding.UTF8, "application/json");
            var client = Global.HTTPCLIENT;
            {
                var httpResponse = await client.SendAsync(httpRequestMessage);
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode && httpResponse.StatusCode != System.Net.HttpStatusCode.Forbidden)
                {
                    Global.GetLogger("Service").LogError($"https://www.starsharks.com/go/auth-api/market/rent-in 失败: {content}");
                    throw new HttpRequestException();
                }
                var responseModel = JsonConvert.DeserializeObject<RentModel>(content);
                return responseModel;
            }
        }

        //internal static async Task<(string,int)> GetGasPriceBySharkId(int sharkId)
        //{

        //}

        public static async Task<Dictionary<int, SharkModel>> GetSharkDetails(IEnumerable<int> sharkIds)
        {
            var c = sharkIds.Select(async sharkId =>
            {
                return new KeyValuePair<int, SharkModel>(sharkId, await GetSharkDetail(sharkId));
            });
            var d = await Task.WhenAll(c);
            return d.ToList().GroupBy(c => c.Key).ToDictionary(c => c.Key, c => c.First().Value);
        }

        public static async Task<SharkModel> GetSharkDetail(int sharkId)
        {
            var uri = $"https://www.starsharks.com/go/api/market/shark-detail?shark_id={sharkId}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            var client = Global.HTTPCLIENT;
            {
                var httpResponse = await client.SendAsync(httpRequestMessage);
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    Global.GetLogger("Service").LogError($"获取鲨鱼详情失败：{uri} 失败: {content}");
                    throw new HttpRequestException();
                }
                var responseModel = JsonConvert.DeserializeObject<SharkDetailModel>(content);
                return responseModel.Data;
            }
        }

        internal static async Task<bool> IsApproveRentContract(string rentAddress)
        {
            var postBody = new
            {
                jsonrpc = "2.0",
                id = 5,
                method = "eth_call",
                @params = new object[] {
                    new {
                        from= "0x0000000000000000000000000000000000000000",
                        data= $"0xdd62ed3e000000000000000000000000{rentAddress[2..].ToLower()}000000000000000000000000e9e092e46a75d192d9d7d3942f11f116fd2f7ca9",
                        to= "0x26193c7fa4354ae49ec53ea2cebc513dc39a10aa"
                    },
                    "latest"
                }
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, Global.BSC_URL);
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(postBody), Encoding.UTF8, "application/json");
            var client = Global.HTTPCLIENT;
            {
                var httpResponse = await client.SendAsync(httpRequestMessage);
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine($"{Global.BSC_URL} 失败: {content}");
                    throw new HttpRequestException();
                }
                var responseModel = JsonConvert.DeserializeObject<JSONRPCResponseModel<string>>(content);
                return new HexBigInteger(responseModel.Result).Value > 0;
            }
        }
        internal static async Task<bool> ApproveContract(string rentAddress)
        {
            var data = "0x095ea7b3000000000000000000000000e9e092e46a75d192d9d7d3942f11f116fd2f7ca9ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

            CancellationTokenSource cs = new CancellationTokenSource();
            var account = Global.Accounts.First(c => c.Account.Address.Equals(rentAddress, StringComparison.CurrentCultureIgnoreCase));

            var tx = new Nethereum.RPC.Eth.DTOs.TransactionInput();
            tx.From = account.Account.Address;
            tx.To = Global.SEA_ADDRESS;
            tx.Data = data.ToString();
            tx.Gas = new HexBigInteger(BigInteger.Parse("60000"));
            tx.GasPrice = new HexBigInteger(Nethereum.Web3.Web3.Convert.ToWei(5, UnitConversion.EthUnit.Gwei));
            var web3 = new Web3(account.Account, Global.BSC_URL);
            web3.TransactionManager.UseLegacyAsDefault = true;
            var receipt = await web3.TransactionManager.SendTransactionAndWaitForReceiptAsync(tx, cs).ConfigureAwait(false);
            return receipt.Status.HexValue.Equals("0x1");
        }

        internal static async Task<(int, string)> RentShark(string rentAddress, int sharkId, int maxPrice, RentLock obj, decimal gasPrice, bool ignoreRentHistory = false, bool dynamicGASPrice = false)
        {
            if (RentedSharkIds.Contains(sharkId) && ignoreRentHistory == false)
            {
                return (-1, "租用冲突");
            }

            RentedSharkIds.Add(sharkId);
            CancellationTokenSource cs = new CancellationTokenSource();
            var account = Global.Accounts.First(c => c.Account.Address.Equals(rentAddress, StringComparison.CurrentCultureIgnoreCase));

        REGET_SHARK:
            RentModel sharkResp = null;
            sharkResp = await GetSharkRentInfo(account, sharkId);
            //sharkResp.Message.StartsWith("price was changed")
            if (sharkResp.Message.StartsWith("account is locking") || sharkResp.Message.StartsWith("block chain is sync"))
            {
                await Task.Delay(200);
                goto REGET_SHARK;
            }
            if (sharkResp.Code == -1)
            {
                if (sharkResp.Message.StartsWith("shark was rented by others"))
                {
                    return (-1, "取消租赁:原因:" + sharkResp.Message);
                }
                else
                {
                    return (-2, "取消租赁:原因:" + sharkResp.Message);
                }
            }

            var price = BigInteger.Parse(sharkResp.Data.Price) / 1000000000000000000;
            if (price != maxPrice)
            {
                return (-1, "价格不一致");
            }
            int nonce = obj.Nonce;
            //lock (obj)
            //{
            if (nonce == obj.Nonce)
            {

                StringBuilder data = new StringBuilder();
                data.Append("0x0bb180e1");
                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.OrderId)).HexValue));
                data.Append(FillZero(new HexBigInteger(sharkResp.Data.NftAddress).HexValue));
                data.Append(FillZero(new HexBigInteger(sharkResp.Data.TokenOwner).HexValue));

                data.Append(FillZero("0x0100"));
                data.Append(FillZero("0x0180"));
                data.Append(FillZero("0x01a0"));

                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.Deadline)).HexValue));
                data.Append(FillZero("0x01c0"));
                data.Append(FillZero("0x0003"));

                data.Append(FillZero(new HexBigInteger(sharkResp.Data.TokenId).HexValue));
                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.ExpireAt)).HexValue));
                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.Price)).HexValue));
                data.Append(FillZero(String.Empty));
                data.Append(FillZero(String.Empty));
                data.Append(FillZero("0x0041"));
                data.Append(RFillZero(sharkResp.Data.Signature, 64 * 3));

                var tx = new Nethereum.RPC.Eth.DTOs.TransactionInput();
                tx.From = account.Account.Address;
                tx.To = Global.RENT_CONTRACT_ADDRESS;
                tx.Data = data.ToString();
                tx.Gas = new HexBigInteger(BigInteger.Parse("300000"));
                var actualGasPrice = gasPrice;
                if (dynamicGASPrice == true)
                {
                    actualGasPrice = Global.GetGasPrice((int)price);
                }
                tx.GasPrice = new HexBigInteger(Nethereum.Web3.Web3.Convert.ToWei(actualGasPrice, UnitConversion.EthUnit.Gwei));
                var web3 = new Web3(account.Account, Global.BSC_URL);
                web3.TransactionManager.UseLegacyAsDefault = true;
                var receipt = await web3.TransactionManager.SendTransactionAndWaitForReceiptAsync(tx, cs);
                obj.Nonce++;
                if (receipt.Status.HexValue.Equals("0x0"))
                {
                    return (-1, string.Empty);
                }
                return (1, string.Empty);
            }
            else
            {
                return (-1, "Nonce超出");
            }
            //}
        }

        internal static async Task<(bool, string)> Withdraw(string address)
        {

            CancellationTokenSource cs = new CancellationTokenSource();
            var account = Global.Accounts.First(c => c.Account.Address.Equals(address, StringComparison.CurrentCultureIgnoreCase));
            var sharkResp = await GetSharkWithdrawInfo(account);
            if (sharkResp.Code == -1)
            {
                return (false, sharkResp.Message);
            }
            else
            {

                /**
                 * 0x07bfe9e6 function name
00000000000000000000000026193c7fa4354ae49ec53ea2cebc513dc39a10aa // SEA
000000000000000000000000000000000000000000000006fe3c108759640000 // Amount
0000000000000000000000000000000000000000000000008d958002e09a8366 // Order Id
0000000000000000000000000000000000000000000000000000000061f39c80 // deadline
00000000000000000000000000000000000000000000000000000000000000a0 // unknown
0000000000000000000000000000000000000000000000000000000000000041 // unknown
19bf250766ffbd0f069865adef2e831bd29f07b06a7c9f4175e53237426c2952 //sign
2d07bf62d8a4a124085662eede9d25fde9d794496fe2e615431511cd45bbd4e3 //sign
1b00000000000000000000000000000000000000000000000000000000000000 //sign
                */
                StringBuilder data = new StringBuilder();
                data.Append("0x07bfe9e6");
                data.Append(FillZero(new HexBigInteger(sharkResp.Data.Token).HexValue));
                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.Amount)).HexValue));
                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.OrderId)).HexValue));
                data.Append(FillZero(new HexBigInteger(BigInteger.Parse(sharkResp.Data.Deadline)).HexValue));
                data.Append(FillZero("0x00a0"));
                data.Append(FillZero("0x0041"));
                data.Append(RFillZero(sharkResp.Data.Sign, 64 * 3));

                var tx = new Nethereum.RPC.Eth.DTOs.TransactionInput();
                tx.From = account.Account.Address;
                tx.To = Global.WITHDRAW_CONTRACT_ADDRESS_V2;
                tx.Data = data.ToString();
                tx.Gas = new HexBigInteger(BigInteger.Parse("200000"));
                tx.GasPrice = new HexBigInteger(Nethereum.Web3.Web3.Convert.ToWei(5.5, UnitConversion.EthUnit.Gwei));
                var web3 = new Web3(account.Account, Global.BSC_URL);
                web3.TransactionManager.UseLegacyAsDefault = true;
                var receipt = await web3.TransactionManager.SendTransactionAndWaitForReceiptAsync(tx, cs).ConfigureAwait(false);
                //var hash = await account.Account.TransactionManager.SignTransactionAsync(tx);
                if (receipt.Status.HexValue.Equals("0x0"))
                {
                    return (false, "提取失败");
                }
                return (true, "提取成功");
            }
        }

        #region 登录
        internal static string Sign(string message, string privateKey)
        {
            var signer1 = new EthereumMessageSigner();
            return signer1.EncodeUTF8AndSign(message, new EthECKey(privateKey));
        }
        internal static async Task<(string WebsiteToken, string GameToken, string Address, Account Account, string Alias)> Login(Account account, string alias, Microsoft.Extensions.Caching.Distributed.IDistributedCache? cache, int maxRetry = 0)
        {
            try
            {
                var content = await cache.GetStringAsync($"StarsharkToken:{account.Address.ToLower()}");
                if (!string.IsNullOrWhiteSpace(content))
                {
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<LoginResponseModel>>(content);
                    if (responseModel?.Data != null)
                    {
                        return (responseModel!.Data!.Authorization!.Remove(0, 7), responseModel!.Data!.QRCode!, account.Address, account, alias);
                    }
                }
                var randomString = await RandomString();
                var httpClient = Global.HTTPCLIENT;
                {
                    var loginRequestModel = new LoginRequestModel
                    {
                        Address = account.Address,
                        RandomString = randomString,
                        Sign = Sign(randomString, account.PrivateKey)
                    };
                    var httpResponse = await httpClient.PostAsync("https://www.starsharks.com/go/api/login/verify-sign", new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json"));
                    content = await httpResponse.Content.ReadAsStringAsync();
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        Global.GetLogger("Service").LogError($"https://www.starsharks.com/go/api/login/verify-sign 失败: {content}");
                        throw new HttpRequestException($"https://www.starsharks.com/go/api/login/verify-sign 失败: {content}");
                    }
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<LoginResponseModel>>(content);
                    await cache.SetStringAsync($"StarsharkToken:{account.Address.ToLower()}", content);
                    if (responseModel?.Data != null)
                    {
                        return (responseModel!.Data!.Authorization!.Remove(0, 7), responseModel!.Data!.QRCode!, account.Address, account, alias);
                    }
                    return await Login(account, alias, cache);
                }
            }
            catch (Exception e)
            {
                Global.GetLogger("Service").LogError(e, e.Message);
                return await Login(account, alias, cache, maxRetry);
            }
        }
        internal static async Task<string> RandomString()
        {
            var httpClient = Global.HTTPCLIENT;
            {
                var httpResponse = await httpClient.GetAsync("https://www.starsharks.com/go/api/login/random-string");
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    Global.GetLogger("Service").LogError($"https://www.starsharks.com/go/api/login/random-string 失败: {content}");
                    throw new HttpRequestException($"https://www.starsharks.com/go/api/login/random-string 失败: {content}");
                }
                var responseModel = JsonConvert.DeserializeObject<ResponseModel<RandomStringModel>>(content);
                return responseModel!.Data!.RandomString!;
            }
        }
        public static async Task<bool> Rename(string address, string newName)
        {
            CancellationTokenSource cs = new CancellationTokenSource();
            var account = Global.Accounts.First(c => c.Account.Address.Equals(address, StringComparison.CurrentCultureIgnoreCase));
            string url = "https://www.starsharks.com/go/auth-api/account/set-name";
            var sharkResp = new WithdrawResponseModel();
            //Global.HTTPCLIENT
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", account.WebsiteToken);
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(new { name = newName }), Encoding.UTF8, "application/json");
            var client = Global.HTTPCLIENT;
            {
                var httpResponse = await client.SendAsync(httpRequestMessage);
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    Global.GetLogger("Service").LogError($"{url} 失败: {content}");
                    throw new HttpRequestException();
                }
                return true;
            }
        }
        public static async Task<List<(int, decimal)>> GetChainRentHistory(int offset, int blockNumberRange, int wantedPrice)
        {
            try
            {
                var web3 = Global.Web3;
                var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                var fromBlock = new HexBigInteger(blockNumber.Value - 28800 + offset);
                var toBlock = new HexBigInteger(blockNumber.Value - 28800 + offset + blockNumberRange);

                var postBody = new
                {
                    jsonrpc = "2.0",
                    id = 2,
                    method = "eth_getLogs",
                    @params = new object[] {
                        new {
                            to = "0xe9e092e46a75d192d9d7d3942f11f116fd2f7ca9",
                            fromBlock = fromBlock.HexValue,
                            toBlock = toBlock.HexValue,
                            topics = new object[] {
                                "0x7e2f81b7354472d47244ac648804708358363207015a363def29272cd465eae1"
                            }
                        }
                    }
                };

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, Global.BSC_URL);
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(postBody), Encoding.UTF8, "application/json");
                var client = Global.HTTPCLIENT;
                {
                    var httpResponse = await client.SendAsync(httpRequestMessage);
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        Global.GetLogger("Service").LogError($"{Global.BSC_URL} 失败: {content}");
                        //throw new HttpRequestException();
                    }
                    var responseModel = JsonConvert.DeserializeObject<JSONRPCResponseModel<LogModel[]>>(content);
                    var result = responseModel.Result.Select(c =>
                    {
                        var price = new HexBigInteger(c.Data.Substring(0, 66)).Value / 1000000000000000000;
                        var sharkId = new HexBigInteger(c.Topics[2]).Value;
                        return ((int)sharkId, (decimal)price);
                    });
                    return result.Where(c => c.Item2 >= wantedPrice - 10 && c.Item2 <= wantedPrice).ToList();
                }


            }
            catch
            {
                return await GetChainRentHistory(offset, blockNumberRange, wantedPrice);
            }
        }
        #endregion
    }
}
