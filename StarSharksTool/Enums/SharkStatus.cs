using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSharksTool.Enums
{
    public enum SharkStatus
    {
        [Description("正常")]
        Normal = 0,
        [Description("租入")]
        RentIn = 1,
        [Description("租出")]
        RentOut = 2,
        [Description("未知")]
        Unknown = 4,
    }
}
