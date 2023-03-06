using Webapi.Data.DataModels;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll();
    }
}
