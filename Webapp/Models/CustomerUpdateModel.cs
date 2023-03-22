namespace Webapp.Models
{
    public class CustomerUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public AddressModel Address { get; set; }
    }
}
