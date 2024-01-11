using ms_travel_easy.src.Models;

namespace ms_travel_easy.src.Services
{
	public interface IAccountService
	{

        Task<List<Account>> GetAllAccountsAsync();

        Task<Account> GetAccountByAccountIdAsync(string accountId);

        Task<Account?> GetAccountByEmailAsync(string email);

        Task CreateAccountAsync(Account newAccount);
    }
}

