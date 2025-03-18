namespace API.Controllers.Entities
{
    public class Filters
    {
        public double? Price { get; set; }

        public string? Name { get; set; }

        public string? Colour { get; set;}

        public string? Country { get; set; }

        public Domain.Entities.Filters ToDomainEntity()
        {
            return new Domain.Entities.Filters
            {
                Price = this.Price,
                Name = this.Name,
                Colour = this.Colour,
                Country = this.Country
            };
        }
    }
}