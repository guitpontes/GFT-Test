using GFTTest.Domain.Orders.Entities;
using GFTTest.Domain.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Infra.OrderRepository
{
    //If was there an Database it would manipulate it here;
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders; 
        public OrderRepository()
        {
            _orders = new List<Order>();
        }
        public void Add(Order order)
        {
            this._orders.Add(order);
        }

        public List<Order> FindAll()
        {
            return this._orders;
        }
    }
}
