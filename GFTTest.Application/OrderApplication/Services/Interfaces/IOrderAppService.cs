using GFTTest.DataTransfer.Requests;
using GFTTest.DataTransfer.Responses;
using GFTTest.Domain.Orders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTTest.Application.OrderApplication.Services.Interfaces
{
    public interface IOrderAppService
    {
        OrderResponse TakeOrder(OrderRequest request);
        List<OrderResponse> GetAllOrders();
    }
}
