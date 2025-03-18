using Data.Entities;
using Data.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Repository
{
    public class SqlPricesRepository : IPricesRepository
    {
        private readonly Context context;

        public SqlPricesRepository(Context context)
        {
            this.context = context;
        }

        public async Task<string> CreatePriceAsync(Price price)
        {
            await this.context.Prices.AddAsync(price);
            await this.context.SaveChangesAsync();

            return this.context.Prices.FirstOrDefault(b => b.Id == price.Id).Id;
        }

        public async Task CreatePricesAsync(IEnumerable<Price> prices)
        {
            await this.context.Prices.AddRangeAsync(prices);
            await this.context.SaveChangesAsync();
        }

        public async Task<string> UpdatePriceAsync(Price price)
        {
            this.context.Prices.UpdateRange(price);
            await this.context.SaveChangesAsync();

            return this.context.Prices.FirstOrDefault(b => b.Id == price.Id).Id;
        }

        public async Task<bool> DeletePriceAsync(string id)
        {
            var price = await this.context.Prices.FirstOrDefaultAsync(b => b.Id == id);

            if (price != null)
            {
                this.context.Prices.Remove(price);
                await this.context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Price> GetPriceByBeanIdAsync(string id)
        {
            return await this.context.Prices.FirstOrDefaultAsync(b => b.BeanId == id);
        }
    }
}