using Models.AccountModels;
using Models.Dto;
using Webapi.Data.DataModels;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();

        Task<AccountDto> GetByEmailAddress(string EmailAddress);
        public void UpdateAccount(int accountId, AccountUpdateModel customer);
        Task CreateAccount(AccountModel account);

        Task<Account?> CheckIfAccountExist(LoginModel input);
    }
}
