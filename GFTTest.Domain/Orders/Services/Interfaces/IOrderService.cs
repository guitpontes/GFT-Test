using GFTTest.Domain.Orders.Entities;
using GFTTest.Domain.Orders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Domain.Orders.Services.Interfaces
{
    public interface IOrderService
    {
        Order TakeOrder(TimeEnum time, Dictionary<int, int> orderList);
    }
}
