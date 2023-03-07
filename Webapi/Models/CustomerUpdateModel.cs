using Webapi.Data.DataModels;

namespace Webapi.Models
{
    public class CustomerUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
