using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;
using Webapi.Models.Dto;

namespace Webapi.Controllers
{
    [Authorize]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{customerId:int}/GetOrderDetailsByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetOrderDetailsByCustomerId(int customerId)
        {
            var result = _orderRepository.GetOrderDetailsByCustomerId(customerId);
            return Ok(result);
        }

        [HttpGet("GetAllOrderDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrderDetails()
        {
            var result = _orderRepository.GetAllOrderDetails();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateOrder(newOrderInput newOrder)
        {
            _orderRepository.CreateOrder(newOrder);
            
            return Ok();
        }
    }
}
