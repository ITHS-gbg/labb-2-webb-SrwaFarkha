using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Data.DataModels;
using Webapi.Data;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Data.Repositories;
using Webapi.Models;

namespace Webapi.Controllers
{
    //[Route["api/[controller]")]
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            var data = _accountRepository.GetAll();

            return Ok(data);
        }

        [HttpGet("{EmailAddress}", Name = "GetAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Account> GetByEmailAddress(string EmailAddress)
        {
            var data = _accountRepository.GetByEmailAddress(EmailAddress);
            return Ok(data);

        }

        [HttpPut("{accountId:int}", Name = "UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateAccount(int accountId, AccountUpdateModel account)
        {
            _accountRepository.UpdateAccount(accountId, account);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult CreateAccount(Account account)
        {
            _accountRepository.CreateAccount(account);
            return Ok();
        }
    }
}
