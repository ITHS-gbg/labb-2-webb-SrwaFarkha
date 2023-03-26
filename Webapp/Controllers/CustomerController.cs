using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;
using Webapp.Extensions;
using Webapp.Interfaces;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ISrwasButikServices _srwasButikServices;

        public CustomerController(ISrwasButikServices srwasButikServices)
        {
            _srwasButikServices = srwasButikServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<ProductCartModel>>("shoppingCart") ?? new List<ProductCartModel>();

            ViewBag.Cart = cart;

            var model = new RegisterCustomerAndCreateOrderModel();

            return View("RegisterCustomerAndCreateOrder", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(RegisterCustomerAndCreateOrderModel data)
        {
            if (data != null)
            {
                var newCustomer = new CustomerModel
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    EmailAddress = data.EmailAddress,
                    PhoneNumber = data.PhoneNumber,
                    Address = new AddressModel
                    {
                        City = data.City,
                        StreetAddress = data.StreetAddress
                    }
                };


                await _srwasButikServices.CreateCustomer(newCustomer);
            }

            return View("Index");
        }
    }
}
