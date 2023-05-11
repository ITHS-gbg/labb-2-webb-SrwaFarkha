using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Models.AccountModels;
using Webapp.Extensions;
using Webapp.Interfaces;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISrwasButikServices _srwasButikServices;

        public AccountController(ISrwasButikServices srwasButikServices)
        {
            _srwasButikServices = srwasButikServices;
        }

        public async Task<IActionResult> Index()
        {
            var accountEmailAddress = User.FindFirstValue(ClaimTypes.Email) ?? "";
            var accountInfo = await _srwasButikServices.GetByEmailAddress(accountEmailAddress);
            
            return View(accountInfo);
        }


        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<ProductCartModel>>("shoppingCart") ?? new List<ProductCartModel>();

            ViewBag.Cart = cart;

            var model = new RegisterAccountModel();

            return View("RegisterAccount", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(RegisterAccountModel data)
        {
            if (data != null)
            {
                var newCustomer = new AccountModel
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    EmailAddress = data.EmailAddress,
                    PhoneNumber = data.PhoneNumber,
            
                    City = data.City,
                    StreetAddress = data.StreetAddress
                };


                await _srwasButikServices.CreateAccount(newCustomer);
            }

            return View("Index");
        }
    }
}
