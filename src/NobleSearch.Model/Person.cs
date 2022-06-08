using Redis.OM.Modeling;
using System.Text.Json.Serialization;

namespace NobleSearch.Model
{
    [Document(IndexName = "Person-idx", StorageType = StorageType.Json)]
    public class Person
    {
        [JsonPropertyName("id")]
        [RedisIdField]
        public string Id { get; set; }

        [JsonPropertyName("year")]
        [Indexed]
        public string Year { get; set; }

        [JsonPropertyName("category")]
        [Searchable(Aggregatable = true)]
        public string Category { get; set; }

        [JsonPropertyName("firstname")]
        [Searchable]
        public string FirstName { get; set; }

        [JsonPropertyName("surname")]
        [Searchable]
        public string Surname { get; set; }

        [JsonPropertyName("motivation")]
        [Searchable]
        public string Motivation { get; set; }

        [JsonPropertyName("share")]
        [Indexed]
        public string Share { get; set; }
    }
}