using Webapi.Data.DataModels;
using Webapi.Models.Dto;

namespace Webapp.Models
{
    public class OrderModel
    {
        public CustomerModel Customer { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
    }
}
