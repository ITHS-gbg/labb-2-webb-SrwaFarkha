using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.OrderModels;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories;
using Webapi.Data.Repositories.Interfaces;

namespace Webapi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{accountId:int}/GetOrderDetailsByAccountId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderDetailsByAccountId(int accountId)
        {
            var result = await _orderRepository.GetOrderDetailsByAccountId(accountId);
            return Ok(result);
        }

        [HttpGet("get-all-order-details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrderDetails()
        {
            var result = _orderRepository.GetAllOrderDetails();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateOrder(NewOrderInputModel newOrder)
        {
            _orderRepository.CreateOrder(newOrder);
            
            return Ok();
        }
    }
}
