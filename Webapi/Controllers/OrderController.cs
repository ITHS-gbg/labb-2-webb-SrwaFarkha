using Microsoft.AspNetCore.Mvc;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;
using Webapi.Models.Dto;

namespace Webapi.Controllers
{
    //[Route["api/[controller]")]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //orderdetails på en specifik order
        [HttpGet("{customerId:int}/GetOrderDetailsByCustomerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetOrderDetailsByCustomerId(int customerId)
        {
            var result = _orderRepository.GetOrderDetailsByCustomerId(customerId);
            return Ok(result);
        }

        //orderdetails på alla ordrar
        [HttpGet("GetAllOrderDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrderDetails()
        {
            var result = _orderRepository.GetAllOrderDetails();
            return Ok(result);
        }

        //spara ordrarna i databasen
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateOrder(newOrderInput newNewOrder)
        {
            _orderRepository.CreateOrder(newNewOrder);
            
            return Ok();
        }
    }
}
