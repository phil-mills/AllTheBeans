using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Bean
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("isBOTD")]
        public bool IsBOTD { get; set; }

        [JsonPropertyName("Cost")]
        public string Cost { get; set; }

        [JsonPropertyName("Image")]
        public string Image { get; set; }

        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }
    }
}