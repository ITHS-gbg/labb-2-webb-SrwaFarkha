
using Models.Dto;

namespace Models.OrderModels
{
    public class newOrderInput
    {
        public DateTime OrderDate { get; set; }
        public AccountDto Account { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }

    }
}
