using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data;
using Webapi.Data.Repositories.Interfaces;

namespace Webapi.Controllers
{
    //[Route["api/[controller]")]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //Hämta alla kunder
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var data = _customerRepository.GetAll();

            return Ok(data);
        }
    }
}
