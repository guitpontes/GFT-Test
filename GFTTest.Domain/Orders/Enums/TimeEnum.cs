using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Domain.Orders.Enums
{
    public enum TimeEnum
    {
        [Description("Morning")]
        Morning = 0,

        [Description("Night")]
        Night = 1,
    }
}
