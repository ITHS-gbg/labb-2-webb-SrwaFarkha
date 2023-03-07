using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public Customer GetByEmailAddress(string EmailAddress)
        {
            var customer = _dbContext.Customers.Include(x => x.Address).FirstOrDefault(x => x.EmailAddress == EmailAddress );
            return customer;
        }

        public void UpdateCustomer(int customerId, CustomerUpdateModel update)
        {

            var customerFromDb = _dbContext.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            if (customerFromDb != null)
            {
                customerFromDb.FirstName = update.FirstName;
                customerFromDb.LastName = update.LastName;
                customerFromDb.PhoneNumber = update.PhoneNumber;
                customerFromDb.Address = update.Address;
                _dbContext.SaveChanges();
            }
        }
    }
}
