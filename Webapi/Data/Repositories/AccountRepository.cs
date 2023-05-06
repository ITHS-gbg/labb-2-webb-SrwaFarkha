using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Webapi.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dbContext;

        public AccountRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Account> GetAll()
        {
            var accounts = _dbContext.Accounts.Include(x => x.Address).ToList(); ;
            return accounts;
        }

        public Account GetByEmailAddress(string EmailAddress)
        {
            var account = _dbContext.Accounts.Include(x => x.Address).FirstOrDefault(x => x.EmailAddress == EmailAddress );
            return account;
        }

        public void UpdateAccount(int accountId, AccountUpdateModel update)
        {

            var accountFromDb = _dbContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
            if (accountFromDb != null)
            {
                accountFromDb.FirstName = update.FirstName;
                accountFromDb.LastName = update.LastName;
                accountFromDb.PhoneNumber = update.PhoneNumber;
                accountFromDb.Password = update.Password;
                accountFromDb.Address = update.Address;
                _dbContext.SaveChanges();
            }
        }

        public void CreateAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }

        public async Task<bool> CheckAccountIsValid(string emailAddress, string password)
        {
            var account = await _dbContext.Accounts
                .FirstOrDefaultAsync(x => x.EmailAddress == emailAddress && x.Password == password);
           
            if (account == null)
            {
                return false;
            }
            
            return true;
        }
    }
}
