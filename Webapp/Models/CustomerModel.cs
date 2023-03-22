using Webapi.Data.DataModels;

namespace Webapp.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public AddressModel Address { get; set; }
    }
}
