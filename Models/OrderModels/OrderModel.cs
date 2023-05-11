using Models.AccountModels;

namespace Models.OrderModels
{
    public class OrderModel
    {
        public AccountModel Account { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
    }
}
