using Models.Dto;
using Models.OrderModels;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
	    Task<List<OrderDto>> GetOrderDetailsByAccountId(int accountId);

		public List<OrderDto> GetAllOrderDetails();
		Task CreateOrder(NewOrderInputModel newNewOrder);

    }
}
