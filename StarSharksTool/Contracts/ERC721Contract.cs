using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;

namespace StarSharksTool.Contracts.ERC721
{
    public class ERC721ContractConsole
    {
        public static async Task Main()
        {
            //var url = "http://testchain.nethereum.com:8545";
            //var url = "https://mainnet.infura.io";
            //var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            //var account = new Nethereum.Web3.Accounts.Account(privateKey);
            //var web3 = new Web3(account, url);

            /* Deployment 
           var eRC721ContractDeployment = new ERC721ContractDeployment();

           var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<ERC721ContractDeployment>().SendRequestAndWaitForReceiptAsync(eRC721ContractDeployment);
           var contractAddress = transactionReceiptDeployment.ContractAddress;
            */
            //var contractHandler = web3.Eth.GetContractHandler("");

            /** Function: approve**/
            /*
            var approveFunction = new ApproveFunction();
            approveFunction.To = to;
            approveFunction.TokenId = tokenId;
            var approveFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(approveFunction);
            */


            /** Function: mint**/
            /*
            var mintFunction = new MintFunction();
            mintFunction.To = to;
            mintFunction.TokenId = tokenId;
            var mintFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(mintFunction);
            */


            /** Function: safeTransferFrom**/
            /*
            var safeTransferFromFunction = new SafeTransferFromFunction();
            safeTransferFromFunction.From = from;
            safeTransferFromFunction.To = to;
            safeTransferFromFunction.TokenId = tokenId;
            var safeTransferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction);
            */


            /** Function: safeTransferFrom**/
            /*
            var safeTransferFromFunction = new SafeTransferFromFunction();
            safeTransferFromFunction.From = from;
            safeTransferFromFunction.To = to;
            safeTransferFromFunction.TokenId = tokenId;
            safeTransferFromFunction.Data = data;
            var safeTransferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction);
            */


            /** Function: setApprovalForAll**/
            /*
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
            setApprovalForAllFunction.To = to;
            setApprovalForAllFunction.Approved = approved;
            var setApprovalForAllFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction);
            */


            /** Function: transferFrom**/
            /*
            var transferFromFunction = new TransferFromFunction();
            transferFromFunction.From = from;
            transferFromFunction.To = to;
            transferFromFunction.TokenId = tokenId;
            var transferFromFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction);
            */


            /** Function: balanceOf**/
            /*
            var balanceOfFunction = new BalanceOfFunction();
            balanceOfFunction.Owner = owner;
            var balanceOfFunctionReturn = await contractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
            */


            /** Function: getApproved**/
            /*
            var getApprovedFunction = new GetApprovedFunction();
            getApprovedFunction.TokenId = tokenId;
            var getApprovedFunctionReturn = await contractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction);
            */


            /** Function: isApprovedForAll**/
            /*
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
            isApprovedForAllFunction.Owner = owner;
            isApprovedForAllFunction.Operator = operator;
            var isApprovedForAllFunctionReturn = await contractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction);
            */


            /** Function: ownerOf**/
            /*
            var ownerOfFunction = new OwnerOfFunction();
            ownerOfFunction.TokenId = tokenId;
            var ownerOfFunctionReturn = await contractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction);
            */


            /** Function: supportsInterface**/
            /*
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
            supportsInterfaceFunction.InterfaceId = interfaceId;
            var supportsInterfaceFunctionReturn = await contractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction);
            */
        }

    }

    public partial class ERC721ContractDeployment : ERC721ContractDeploymentBase
    {
        public ERC721ContractDeployment() : base(BYTECODE) { }
        public ERC721ContractDeployment(string byteCode) : base(byteCode) { }
    }

    public class ERC721ContractDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public ERC721ContractDeploymentBase() : base(BYTECODE) { }
        public ERC721ContractDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true)]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false)]
        public virtual bool Approved { get; set; }
    }













    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
