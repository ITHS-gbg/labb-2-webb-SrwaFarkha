using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;

namespace Webapi.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dbContext;

        public CustomerRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Customer> GetAll()
        {
            var customers = _dbContext.Customers.Include(x => x.Address).ToList(); ;
            return customers;
        }
    }
}
