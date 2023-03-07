using Webapi.Data.DataModels;
using Webapi.Models;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IProductRepository
    { 
        public List<Product> GetAll();

        public Product GetByName(string name);

        public void CreateProduct(Product product);
        public void DeleteProduct(int id);
        public void UpdateProduct(int productId, ProductUpdateModel update);
    }
}
