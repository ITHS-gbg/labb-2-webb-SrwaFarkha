using Models.Dto;
using Models.ProductModels;
using Webapi.Data.DataModels;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IProductRepository
    { 
        List<ProductDto> GetAll();
        ProductDto GetByName(string name);
        void CreateProduct(CreateProductModel product);
        void DeleteProduct(int id);
        void UpdateProduct(int productId, ProductUpdateModel update);
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        ProductDto GetById(int productId);
    }
}
