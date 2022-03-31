using Nethereum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Refactor.Models
{
    public class StarsharkAccount
    {
        public string GameToken { get; set; }
        public string WebsiteToken { get; set; }
        public List<object> Sharks { get; set; }
        public StarsharkAccount(Account account, string Alias)
        {

        }
    }
}
