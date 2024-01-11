using MongoDB.Bson.Serialization.Attributes;

namespace ms_travel_easy.src.Models
{
    [BsonIgnoreExtraElements]
    public class Account
    {

        [BsonElement("AccountId")]
        public string AccountId { get; set; } = null!;

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("LastName")]
        public string LastName { get; set; } = null!;

        [BsonElement("Email")]
        public string Email { get; set; } = null!;

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

    }
}

