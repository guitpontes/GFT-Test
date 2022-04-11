using GFTTest.Application.OrderApplication.Services.Interfaces;
using GFTTest.DataTransfer.Requests;
using GFTTest.DataTransfer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFTTest.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            this.orderAppService = orderAppService;
        }

        /// <summary>
        /// TODO Method since don't have DB connection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<OrderResponse>> Get()
        {
            return orderAppService.GetAllOrders();
        }

        /// <summary>
        /// Make an order
        /// </summary>
        /// <param name="request">Time must be morning or nigth and order between 1 - 4</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<OrderResponse> TakeOrder([FromBody]OrderRequest request)
        {
            return Ok(orderAppService.TakeOrder(request));
        }
    }
}
