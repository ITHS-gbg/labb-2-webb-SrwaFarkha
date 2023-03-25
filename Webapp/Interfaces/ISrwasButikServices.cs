using Webapp.Models;

namespace Webapp.Interfaces
{
    public interface ISrwasButikServices
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProductByName(string productName);
        Task<ProductModel> GetProductById(int productId);
        Task<bool> CreateProduct(CreateNewProductModel model);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int productId, ProductUpdateModel product);
        Task<List<CustomerModel>> GetCustomers();
        Task<List<CustomerModel>> GetByEmailAddress(string EmailAddress);
        Task<bool> UpdateCustomer(int customerId, CustomerUpdateModel customer);
        Task<bool> CreateCustomer(CustomerModel customer);
        Task<List<OrderModel>> GetAllOrderDetails();
        Task<List<OrderModel>> GetOrderDetailsByCustomerId(int customerId);
        Task<bool> CreateOrder(NewOrderInputModel newOrder);
        Task<List<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategoryById(int categoryId);
    }
}
