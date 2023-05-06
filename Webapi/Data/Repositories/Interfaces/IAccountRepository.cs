using Webapi.Data.DataModels;
using Webapi.Models;

namespace Webapi.Data.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();

        public Account GetByEmailAddress(string EmailAddress);
        public void UpdateAccount(int accountId, AccountUpdateModel customer);
        public void CreateAccount(Account account);

        Task<bool> CheckAccountIsValid(string emailAddress, string password);
    }
}
