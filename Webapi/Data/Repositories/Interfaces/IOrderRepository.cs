using Models.Dto;
using Models.OrderModels;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<OrderDto> GetOrderDetailsByAccountId(int accountId);
        public List<OrderDto> GetAllOrderDetails();
        public void CreateOrder(newOrderInput newNewOrder);
    }
}
