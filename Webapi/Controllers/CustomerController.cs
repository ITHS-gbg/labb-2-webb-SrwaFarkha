using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Data.Repositories;
using Webapi.Models;

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

        //Hämtar en kund baserat på mail
        [HttpGet("{EmailAddress}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Customer> GetByEmailAddress(string EmailAddress)
        {
            var data = _customerRepository.GetByEmailAddress(EmailAddress);
            return Ok(data);

        }

        //updaterar kunden baserat på id
        [HttpPut("{customerId:int}", Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateCustomer(int customerId, CustomerUpdateModel customer)
        {
            _customerRepository.UpdateCustomer(customerId, customer);
            return Ok();
        }
    }
}
