
using Models.AccountModels;

namespace Models.OrderModels
{
    public class NewOrderInputModel
    {
        public DateTime OrderDate { get; set; }
        public AccountModel Account { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }

    }
}
