using System.Text.Json.Serialization;

namespace API.Controllers.Entities
{
    public class Bean
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("isBOTD")]
        public bool IsBOTD { get; set; }

        [JsonPropertyName("cost")]
        public string Cost { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        public Domain.Entities.Bean ToDomainBean()
        {
            return new Domain.Entities.Bean();
        }
    }
}