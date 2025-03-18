using Data.Entities;
using Data.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Repository
{
    public class BOTDRepository : IBOTDRepository
    {
        private readonly Context context;

        public BOTDRepository(Context context)
        {
            this.context = context;
        }

        public async Task CreateBOTDAsync(BOTD botd)
        {
            // only allow 1 BOTD record
            if (this.context.BOTD.FirstOrDefault() != null)
            {
                return;
            }

            await this.context.BOTD.AddAsync(botd);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateBOTDAsync(BOTD botd)
        {
            var existingBean = await this.context.BOTD.FindAsync(botd.Id);

            if (existingBean != null)
            {
                this.context.Entry(existingBean).CurrentValues.SetValues(botd);
                await this.context.SaveChangesAsync();
            }
        }

        public Task<BOTD> GetBOTDAsync()
        {
            return this.context.BOTD.FirstOrDefaultAsync();
        }
    }
}