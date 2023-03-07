using Webapi.Data.DataModels;
using Webapi.Models;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();

        public Customer GetByEmailAddress(string EmailAddress);
        public void UpdateCustomer(int customerId, CustomerUpdateModel customer);
    }
}
