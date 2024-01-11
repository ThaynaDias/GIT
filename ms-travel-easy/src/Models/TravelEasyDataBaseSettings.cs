namespace ms_travel_easy.src.Models
{
	public class TravelEasyDataBaseSettings
	{
        public string ConnectionString { get; set; } = null!;

        public string CustomerDatabaseName { get; set; } = null!;

        public string BookingDatabaseName { get; set; } = null!;

        public string AccountsCollectionName { get; set; } = null!;

        public string BookingsCollectionName { get; set; } = null!;
    }
}

