using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.AccountModels;
using Models.Dto;
using Webapi.Data.DataModels;
using Webapi.Data.Repositories.Interfaces;
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

        public async Task<AccountDto> GetByEmailAddress(string EmailAddress)
        {
            var account = await _dbContext.Accounts
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.EmailAddress == EmailAddress);

            var accountDto = new AccountDto
            {
                AccountId = account.AccountId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                EmailAddress = account.EmailAddress,
                PhoneNumber = account.PhoneNumber,
       
                City = account.Address.City,
                StreetAddress = account.Address.StreetAddress
            };

            return accountDto;
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
                accountFromDb.Address = new Address
                {
                    AddressId = update.Address.AddressId,
                    City = update.Address.City,
                    StreetAddress = update.Address.StreetAddress
                };
                _dbContext.SaveChanges();
            }
        }

        public async Task CreateAccount(AccountModel account)
        {
	        var newAccount = new Account
	        {
		        FirstName = account.FirstName,
		        LastName = account.LastName,
		        EmailAddress = account.EmailAddress,
		        Password = account.Password,
		        PhoneNumber = account.PhoneNumber,
		        Address = new Address
		        {
			        City = account.City,
			        StreetAddress = account.StreetAddress,
		        }
	        };
	        _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Account?> CheckIfAccountExist(LoginModel input)
        {
            var account = await _dbContext.Accounts
                .FirstOrDefaultAsync(x => x.EmailAddress == input.EmailAddress  && x.Password == input.Password);

            return account;
        }
    }
}
