using Microsoft.CodeAnalysis;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using Webapi.Data.DataModels;
using Webapi.Models.Dto;
using Webapp.Interfaces;
using Webapp.Models;

namespace Webapp.Services
{
    public class SrwasButikServices : ISrwasButikServices
    {
        private readonly string _baseUrl = "https://localhost:7207/api/";
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _http;

        public SrwasButikServices(HttpClient http)
        {
            _http = http;

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        //GET products
        public async Task<List<ProductModel>> GetProducts()
        {
            var response = await _http.GetAsync($"{_baseUrl}product");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProductModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        //Hämtar en product baserat på namn
        public async Task<List<ProductModel>> GetProducts(string name)
        {
            var response = await _http.GetAsync($"{_baseUrl}product{name}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ProductModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        //Create product
        public async Task<bool> CreateProduct(CreateNewProductModel model)
        {
            try
            {
                var url = _baseUrl + "product";
                var data = JsonSerializer.Serialize(model);

                var response = await _http.PostAsync(url, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete product
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var url = $"{_baseUrl}products/{id}";
                var response = await _http.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update product based by id
        public async Task<bool> UpdateProduct(int productId, ProductUpdateModel product)
        {
            try
            {
                var url = $"{_baseUrl}products/{productId}";
                var data = JsonSerializer.Serialize(product);
                var response = await _http.PutAsync(url, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //CUSTOMERS
        //GET all customers
        public async Task<List<CustomerModel>> GetCustomers()
        {
            var response = await _http.GetAsync($"{_baseUrl}customer");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<CustomerModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        //Hämtar en kund baserat på mail
        public async Task<List<CustomerModel>> GetByEmailAddress(string EmailAddress)
        {
            var response = await _http.GetAsync($"{_baseUrl}customer{EmailAddress}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<CustomerModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        //updaterar kunden baserat på id
        public async Task<bool> UpdateCustomer(int customerId, CustomerUpdateModel customer)
        {
            try
            {
                var url = $"{_baseUrl}customer/{customerId}";
                var data = JsonSerializer.Serialize(customer);
                var response = await _http.PutAsync(url, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Create Customer

        public async Task<bool> CreateCustomer(CustomerModel customer)
        {
            try
            {
                var url = _baseUrl + "customers";
                var data = JsonSerializer.Serialize(customer);

                var response = await _http.PostAsync(url, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //ORDER
        //GET all order
        public async Task<List<OrderModel>> GetAllOrderDetails()
        {
            var response = await _http.GetAsync($"{_baseUrl}order");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<OrderModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        //orderdetails på en specifik order by id
        public async Task<List<OrderModel>> GetOrderDetailsByCustomerId(int customerId)
        {
            var response = await _http.GetAsync($"{_baseUrl}order{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<OrderModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        public async Task<List<CategoryModel>> GetCategories()
        {
            var response = await _http.GetAsync($"{_baseUrl}product/GetCategories");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<CategoryModel>>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        public async Task<CategoryModel> GetCategoryById(int categoryId)
        {
            var response = await _http.GetAsync($"{_baseUrl}product/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<CategoryModel>(data, _options);
                return result;
            }
            else
            {
                throw new Exception("Det gick inget vidare");
            }
        }

        //Create order
        public async Task<bool> CreateOrder(NewOrderInputModel newOrder)
        {
            try
            {
                var url = _baseUrl + "orders";
                var data = JsonSerializer.Serialize(newOrder);

                var response = await _http.PostAsync(url, new StringContent(data, Encoding.Default, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
