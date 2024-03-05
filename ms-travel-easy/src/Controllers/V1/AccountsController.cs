using Microsoft.AspNetCore.Mvc;
using ms_travel_easy.src.Models;
using ms_travel_easy.src.Services;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ms_travel_easy.src.Controllers
{
    [ApiController]
    [Route("api/v1/Customer/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountsService;

        public AccountsController(IAccountService productsService) =>
            _accountsService = productsService;

        [HttpGet]
        public async Task<List<Account>> Get() =>
            await _accountsService.GetAllAccountsAsync();

        [HttpGet("{email}")]
        public async Task<ActionResult<Account>> Get(string email)
        {
            if (!IsValidEmail(email))
            {
                var badResponse = new
                {
                    message = "The Email format is incorrect.",
                    ErrorCode = "BAD_EMAIL_FORMAT"
                };

                return BadRequest(badResponse);
            }

            var account = await _accountsService.GetAccountByEmailAsync(email);

            if (account is null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpPost]
        public async Task<ActionResult<Account>> Post(AccountRequest accountRequest)
        {
            if (!IsValidEmail(accountRequest.Email))
            {
                var badResponse = new
                {
                    message = "The Email format is incorrect.",
                    ErrorCode = "BAD_EMAIL_FORMAT",
                };

                return BadRequest(badResponse);
            }

            Account newAccount = new Account
            {
                AccountId = Guid.NewGuid().ToString("D"),
                Name = accountRequest.Name,
                LastName = accountRequest.LastName,
                Email = accountRequest.Email,
                PhoneNumber = accountRequest.PhoneNumber
            };
            await _accountsService.CreateAccountAsync(newAccount);
            return Created("", newAccount);
        }

        private bool IsValidEmail(string email)
        {
            // Implemente a lógica para validar o formato do email aqui
            // Exemplo simples usando Regex:
            var regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            return regex.IsMatch(email);
        }
    }
}
