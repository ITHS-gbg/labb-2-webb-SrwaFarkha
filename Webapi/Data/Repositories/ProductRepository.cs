using Microsoft.EntityFrameworkCore;
using Webapi.Controllers;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;
using Webapi.Models.Dto;

namespace Webapi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductDto> GetAll()
        {
            //mappa om products till productDto
            var products = _dbContext.Products
                .Include(x => x.Category)
                .Select(x => new ProductDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductDescription = x.ProductDescription,
                    Price = x.Price,
                    Category = x.Category,
                    Discontinued = x.Discontinued
                }).ToList();

            return products;
        }

        public Product GetByName(string name)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductName ==  name);
            return product;
        }

        public void CreateProduct(CreateProductModel product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                CategoryId = product.Category.Id,
                Discontinued = false,
            };


            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(int productId, ProductUpdateModel update)
        {
            var productFromDb = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            if (productFromDb != null)
            {
                productFromDb.ProductName = update.ProductName;
                productFromDb.ProductDescription = update.ProductDescription;
                productFromDb.Price = update.Price;
                _dbContext.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            var categories = _dbContext.Products
                .Include(x => x.Category)
                .Select(x => x.Category)
                .Distinct()
                .ToList();

            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            var categories = _dbContext.Products
                .Include(x => x.Category)
                .Select(x => x.Category)
                .Distinct()
                .ToList();

            var filteredCategory = categories.FirstOrDefault(x => x.Id == categoryId);

            return filteredCategory;
        }
    }
}
