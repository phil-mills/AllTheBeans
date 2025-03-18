using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Repository
{
    public class SqlDetailsRepository : IDetailsRepository
    {
        private readonly Context context;

        public SqlDetailsRepository(Context context)
        {
            this.context = context;
        }

        public async Task<string> CreateDetailsAsync(Details details)
        {
            await this.context.Details.AddAsync(details);
            await this.context.SaveChangesAsync();

            return this.context.Prices.FirstOrDefault(b => b.Id == details.Id).Id;
        }

        public async Task CreateDetailsAsync(IEnumerable<Details> details)
        {
            await this.context.Details.AddRangeAsync(details);
            await this.context.SaveChangesAsync();
        }

        public async Task<string> UpdateDetailsAsync(Details details)
        {
            this.context.Details.UpdateRange(details);
            await this.context.SaveChangesAsync();

            return this.context.Prices.FirstOrDefault(b => b.Id == details.Id).Id;
        }

        public async Task<bool> DeleteDetailsAsync(string id)
        {
            var details = await this.context.Details.FirstOrDefaultAsync(b => b.Id == id);

            if (details != null)
            {
                this.context.Details.Remove(details);
                await this.context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Details> GetDetailsByBeanIdAsync(string id)
        {
            return await this.context.Details.FirstOrDefaultAsync(b => b.BeanId == id);
        }
    }
}