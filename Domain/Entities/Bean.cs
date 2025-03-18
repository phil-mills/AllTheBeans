using System.Text.Json.Serialization;
using Data.Entities;

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

        public Data.Entities.Bean ToDataEntity()
        {
            return new Data.Entities.Bean
            {
                Id = this.Id,
                Index = this.Index,
                IsBOTD = this.IsBOTD,
                Price = new Data.Entities.Price
                {
                    Cost = this.Cost
                },
                Details = new Data.Entities.Details
                {
                    Image = this.Image,
                    Colour = this.Colour,
                    Name = this.Name,
                    Description = this.Description,
                    Country = this.Country
                }
            };
        }

        public Bean FromDataEntity(Data.Entities.Bean bean)
        {
            return new Bean
            {
                Id = bean.Id,
                Index = bean.Index,
                IsBOTD = bean.IsBOTD,
                Cost = bean.Price.Cost,
                Image = bean.Details.Image,
                Colour = bean.Details.Colour,
                Name = bean.Details.Name,
                Description = bean.Details.Description,
                Country = bean.Details.Country
            };
        }
    }
}