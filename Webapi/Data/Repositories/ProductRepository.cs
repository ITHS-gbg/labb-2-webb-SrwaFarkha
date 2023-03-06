using Webapi.Controllers;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;

namespace Webapi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAll()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }

        public Product GetByName(string name)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductName ==  name);
            return product;
        }

        public void CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
