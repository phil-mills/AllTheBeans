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

        public Data.Entities.Bean ToDataBeans()
        {
            return new Data.Entities.Bean
            {
                Id = this.Id,
                Index = this.Index,
                IsBOTD = this.IsBOTD
            };
        }

        public Data.Entities.Price ToDataPrice()
        {
            return new Data.Entities.Price
            {
                Id = Guid.NewGuid().ToString(),
                BeanId = this.Id,
                Cost = this.Cost
            };
        }

        public Data.Entities.Details ToDataDetails()
        {
            return new Data.Entities.Details
            {
                Id = Guid.NewGuid().ToString(),
                BeanId = this.Id,
                Description = this.Description,
                Image = this.Image,
                Colour = this.Colour,
                Name = this.Name,
                Country = this.Country
            };
        }

        public Bean FromDataEntities(Data.Entities.Bean bean, Data.Entities.Price price, Data.Entities.Details details)
        {
            return new Bean
            {
                Id = bean.Id,
                Index = bean.Index,
                IsBOTD = bean.IsBOTD,
                Cost = price.Cost,
                Image = details.Image,
                Colour = details.Colour,
                Name = details.Name,
                Description = details.Description,
                Country = details.Country
            };
        }
    }
}