using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webapi.Data.DataModels;
using Webapp.Interfaces;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISrwasButikServices _srwasButikServices;

        public ProductController(ISrwasButikServices srwasButikServices)
        {
            _srwasButikServices = srwasButikServices;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _srwasButikServices.GetProducts();
            return View(result);
        }

        [HttpGet()]

        public async Task<IActionResult> Create()
        {
            var categories = await _srwasButikServices.GetCategories();
            if (categories != null)
            {
                ViewBag.CategoryList = new SelectList(categories, "Id", "Name");
            }

            var model = new CreateNewProductModel();
            return View("Create", model);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CreateNewProductModel data, int SelectedCategoryId)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View("Create", data);
            //};

            var category = await _srwasButikServices.GetCategoryById(SelectedCategoryId);

            //var categoryToInsert = new Category
            //{
            //    Id = category.Id,
            //    Name = category.Name
            //};

            var newProduct = new CreateNewProductModel
            {
                ProductName = data.ProductName,
                ProductDescription = data.ProductDescription,
                Price = data.Price,
                Category = category,
                Discontinued = false
            };

            try
            {
                if (await _srwasButikServices.CreateProduct(newProduct))
                {
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception)
            {
                return View("Error");
            }

            return View("Error");
        }

        public async Task<IActionResult> Delete(int productId)
        {
            if (await _srwasButikServices.DeleteProduct(productId)) return RedirectToAction("Index");
            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            var product = await _srwasButikServices.GetByProductId(productId);
            var model = new ProductUpdateModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price
            };
            return View("Edit", model);
        }
    }
}
