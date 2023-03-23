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
                    CategoryName = x.Category.Name,
                    Discontinued = x.Discontinued
                }).ToList();

            return products;
        }

        public ProductDto GetByName(string name)
        {
            var product = _dbContext.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductName ==  name);

            var productDto = new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                CategoryName = product.Category.Name,
                Discontinued = product.Discontinued
            };

            return productDto;
        }

        public ProductDto GetById(int productId)
        {
            var product = _dbContext.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == productId);

            var productDto = new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Price = product.Price,
                CategoryName = product.Category.Name,
                Discontinued = product.Discontinued
            };

            return productDto;
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
