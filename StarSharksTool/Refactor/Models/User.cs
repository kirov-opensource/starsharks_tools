using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Refactor.Models
{
    public class User
    {
        public Account BSCAccount;
        public StarsharkAccount StarsharkAccount;
        public User(string privateKey, string alias)
        {
        }
    }
}
