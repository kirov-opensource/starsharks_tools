using Newtonsoft.Json;
using StarSharksTool.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Models
{
    public class AccountInfo
    {
        public string PrivateKey { get; set; }
        [JsonIgnore]
        public string DecryptedPrivateKey
        {
            get
            {
                return AESHelper.Decrypt(PrivateKey);
            }
        }
        public string Alias { get; set; }
    }
}
