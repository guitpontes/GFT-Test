using GFTTest.Application.OrderApplication.Services.Interfaces;
using GFTTest.DataTransfer.Requests;
using GFTTest.DataTransfer.Responses;
using GFTTest.Domain.Orders.Entities;
using GFTTest.Domain.Orders.Enums;
using GFTTest.Domain.Orders.Interfaces;
using GFTTest.Domain.Orders.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Application.OrderApplication.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(IOrderService orderService, IOrderRepository orderRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
        }
        public List<OrderResponse> GetAllOrders()
        {
            var response = new List<OrderResponse>();
            
            var orders = this._orderRepository.FindAll();

            foreach (var order in orders)
            {
                response.Add(new OrderResponse { Order = order.ToString() });
            }

            return response;
        }

        public OrderResponse TakeOrder(OrderRequest request)
        {
            try
            {
                TimeEnum timeEnum;
                Dictionary<int, int> dictionaryList = new();

                if (request.Time != null)
                {
                    if (string.Equals(request.Time, "morning", StringComparison.OrdinalIgnoreCase))
                        timeEnum = TimeEnum.Morning;
                    else if (string.Equals(request.Time, "night", StringComparison.OrdinalIgnoreCase))
                        timeEnum = TimeEnum.Night;
                    else
                        throw new Exception("Time must have a value equal: morning or night");
                }
                else
                {
                    throw new Exception("Time must have a value: morning or night");
                }

                foreach (int item in request.OrderList)
                {
                    if (dictionaryList.ContainsKey(item))
                        dictionaryList[item]++;
                    else
                        dictionaryList.Add(item, 1);
                }

                Order order = this._orderService.TakeOrder(timeEnum, dictionaryList);

                OrderResponse response = new() { Order = order.ToString() };

                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
