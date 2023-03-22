using Webapi.Data.DataModels;
using Webapi.Models;
using Webapi.Models.Dto;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IProductRepository
    { 
        List<ProductDto> GetAll();
        Product GetByName(string name);
        void CreateProduct(CreateProductModel product);
        void DeleteProduct(int id);
        void UpdateProduct(int productId, ProductUpdateModel update);
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
    }
}
