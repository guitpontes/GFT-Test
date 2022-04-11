using GFTTest.Domain.Orders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.DataTransfer.Requests
{
    public class OrderRequest
    {
        public string? Time { get; set; }
        public List<int> OrderList { get; set; } = new List<int>();
    }
}
