
using Webapp.Models;

namespace Webapp.Models
{
    public class NewOrderInputModel
    {
        public DateTime OrderDate { get; set; }
        public CustomerModel Customer { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }

    }
}
