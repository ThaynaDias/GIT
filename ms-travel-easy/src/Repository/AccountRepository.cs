using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ms_travel_easy.src.Models;

namespace ms_travel_easy.src.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accountCollection;

        public AccountRepository(
            IOptions<TravelEasyDataBaseSettings> customerDataBaseSettings)
        {
            var mongoClient = new MongoClient(
                customerDataBaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                customerDataBaseSettings.Value.CustomerDatabaseName);

            _accountCollection = mongoDatabase.GetCollection<Account>(
                customerDataBaseSettings.Value.AccountsCollectionName);
        }

        public async Task<List<Account>> GetAsync() =>
            await _accountCollection.Find(_ => true).ToListAsync();

        public async Task<Account> GetAccountAsync(string accountId) =>
            await _accountCollection.Find(x => x.AccountId == accountId).FirstOrDefaultAsync();

        public async Task<Account?> GetAsync(string email) =>
         await _accountCollection.Find(x => x.Email == email).FirstOrDefaultAsync();

        public async Task CreateAsync(Account newAccount) =>
            await _accountCollection.InsertOneAsync(newAccount);
    }
}

