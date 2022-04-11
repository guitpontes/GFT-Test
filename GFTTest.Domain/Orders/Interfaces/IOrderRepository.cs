using GFTTest.Domain.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Domain.Orders.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> FindAll();
        void Add(Order order);

    }
}
