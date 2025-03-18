using Data.Entities;

namespace Data.Persistence.Repository.Interfaces
{
    public interface IPricesRepository
    {
        public Task<string> CreatePriceAsync(Price price);

        public Task CreatePricesAsync(IEnumerable<Price> prices);

        public Task<string> UpdatePriceAsync(Price price);

        public Task<bool> DeletePriceAsync(string id);

        public Task<Price> GetPriceByBeanIdAsync(string id);
    }
}