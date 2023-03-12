using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;
using Webapi.Models.Dto;

namespace Webapi.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dbContext;

        public OrderRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<OrderDto> GetOrderDetailsByCustomerId(int customerId)
        {
            //först hämtar vi allt, sen selectar vi vad vi vill visa
            var result = _dbContext.Orders
                .Include(x => x.Customer)
                .ThenInclude(x => x.Address)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .Where(x => x.CustomerId == customerId)
                .Select(x => new OrderDto
                {
                    Customer = x.Customer,
                    OrderDetails = x.OrderDetails.Select(x => new OrderDetailsDto
                    {
                        ProductId = x.ProductId,
                        ProductName = x.Product.ProductName,
                        Quantity = x.Quantity,
                        Price = x.Price

                    }).ToList()
                }).ToList();

            return result;
        }

        public List<OrderDto> GetAllOrderDetails()
        {
            var result = _dbContext.Orders
                .Include(x => x.Customer)
                .ThenInclude(x => x.Address)
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .Select(x => new OrderDto
                {
                    Customer = x.Customer,
                    OrderDetails = x.OrderDetails.Select(x => new OrderDetailsDto
                    {
                        ProductId = x.ProductId,
                        ProductName = x.Product.ProductName,
                        Quantity = x.Quantity,
                        Price = x.Price,

                    }).ToList()
                }).ToList();

            return result;

        }

        public void CreateOrder(newOrderInput newNewOrder)
        {
            //skapar kund
            _dbContext.Customers.Add(newNewOrder.Customer);
            _dbContext.SaveChanges();

            //hämtar kund
            var newCustomer =
                _dbContext.Customers.FirstOrDefault(x => x.EmailAddress == newNewOrder.Customer.EmailAddress);

            //skapar nytt objekt av order(orderdetails är tom)
            var order = new Order
            {
                OrderDate = newNewOrder.OrderDate,
                CustomerId = newCustomer.CustomerId,
                OrderDetails = new List<OrderDetails>()
            };

            //sätter värderna på orderdetails
            foreach (var detail in newNewOrder.OrderDetails)
            {
                var product = _dbContext.Products.Find(detail.ProductId);
                //för varje loop den går skapar vi en ny objekt för orderdetails
                var orderDetail = new OrderDetails
                {
                    ProductId = product.ProductId,
                    Quantity = detail.Quantity,
                    Price = detail.Quantity*product.Price,
                };

                order.OrderDetails.Add(orderDetail);
            }

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}
