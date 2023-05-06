using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Webapi.Data.Repositories.Interfaces;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public LoginController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        private async Task<bool> IsValidUser(string emailAddress, string password)
        {
            if (emailAddress == "" || password == "")
            {
                return false;
            }
            
            return await _accountRepository.CheckAccountIsValid(emailAddress, password);
        }
    }
}
