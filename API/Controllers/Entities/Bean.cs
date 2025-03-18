using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Controllers.Entities
{
    public class Bean
    {
        [Required]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [Required]
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [Required]
        [JsonPropertyName("isBOTD")]
        public bool IsBOTD { get; set; }

        [Required]
        [JsonPropertyName("cost")]
        public string Cost { get; set; }

        [Required]
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [Required]
        [JsonPropertyName("colour")]
        public string Colour { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        public Domain.Entities.Bean ToDomainBean()
        {
            return new Domain.Entities.Bean
            {
                Id = this.Id,
                Index = this.Index,
                IsBOTD = this.IsBOTD,
                Cost = this.Cost,
                Image = this.Image,
                Colour = this.Colour,
                Name = this.Name,
                Description = this.Description,
                Country = this.Country
            };
        }
    }
}