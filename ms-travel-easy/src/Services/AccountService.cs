using ms_travel_easy.src.Models;
using ms_travel_easy.src.Repository;

namespace ms_travel_easy.src.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<Account>> GetAllAccountsAsync() =>
            await _accountRepository.GetAsync();

        public async Task<Account> GetAccountByAccountIdAsync(string accountId) =>
            await _accountRepository.GetAccountAsync(accountId);

        public async Task<Account?> GetAccountByEmailAsync(string email) =>
            await _accountRepository.GetAsync(email);

        public async Task CreateAccountAsync(Account newAccount) =>
            await _accountRepository.CreateAsync(newAccount);
    }
}

