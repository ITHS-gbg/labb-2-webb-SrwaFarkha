using Webapi.Data.DataModels;

namespace Webapi.Models.Dto
{
    public class OrderDto
    {
        public Account Customer { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }
}
