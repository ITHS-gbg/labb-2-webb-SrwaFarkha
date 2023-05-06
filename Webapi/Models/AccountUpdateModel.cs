using Webapi.Data.DataModels;

namespace Webapi.Models
{
    public class AccountUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public Address Address { get; set; }
    }
}
