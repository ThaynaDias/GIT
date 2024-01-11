using ms_travel_easy.src.Models;

namespace ms_travel_easy.src.Repository
{
	public interface IAccountRepository
	{
        Task<List<Account>> GetAsync();

        Task<Account> GetAccountAsync(string accountId);

        Task<Account?> GetAsync(string email);

        Task CreateAsync(Account newAccount);
    }
}

