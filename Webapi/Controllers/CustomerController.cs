using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data;

namespace Webapi.Controllers
{
    //[Route["api/[controller]")]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomerController(DataContext db)
        {
            _dataContext = db;
        }

        //Hämta alla kunder
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var data = _dataContext.Customers.Include(x => x.Address).ToList();

            return Ok(data);
        }
    }
}
