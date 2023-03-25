using Microsoft.AspNetCore.Mvc;
using Webapp.Extensions;
using Webapp.Interfaces;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ISrwasButikServices _srwasButikServices;

        public ShoppingCartController(ISrwasButikServices srwasButikServices)
        {
            _srwasButikServices = srwasButikServices;
        }

        public async Task<IActionResult> Index()
        {
            var shoppingCart = HttpContext.Session.GetObjectFromJson<List<ProductCartModel>>("shoppingCart") ?? new List<ProductCartModel>();
            return View(shoppingCart);
        }

        //public async Task<IActionResult> AddToCart(int productId)
        //{
        //    var cart = HttpContext.Session.GetObjectFromJson<List<ProductCartModel>>("shoppingCart") ?? new List<ProductCartModel>();
        //    var product = await _srwasButikServices.GetProductById(productId);
        //    cart.Add(new ProductCartModel
        //    {
        //        ProductId = product.ProductId,
        //        ProductName = product.ProductName,
        //        ProductDescription = product.ProductDescription,
        //        Price = product.Price,
        //        CategoryName = product.CategoryName,
        //        Discontinued = product.Discontinued,
        //        Quantity = 1,
        //    });

        //    HttpContext.Session.SetObjectAsJson("cart", cart);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult RemoveFromCart(int productId)
        //{
        //    var cart = HttpContext.Session.GetObjectFromJson<List<ProductCartModel>>("shoppingCart") ?? new List<ProductCartModel>();
        //    var item = cart.FirstOrDefault(i => i.ProductId == productId);
        //    if (item != null)
        //    {
        //        cart.Remove(item);
        //        HttpContext.Session.SetObjectAsJson("shoppingCart", cart);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
