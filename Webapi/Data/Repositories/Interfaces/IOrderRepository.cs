using Webapi.Data.DataModels;
using Webapi.Models;
using Webapi.Models.Dto;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<OrderDto> GetOrderDetailsByCustomerId(int customerId);
        public List<OrderDto> GetAllOrderDetails();
        public void CreateOrder(newOrderInput newNewOrder);
    }
}
