using Data.Entities;
using Data.Persistence.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Repository
{
    public class SqlBeanRepository : IBeansRepository
    {
        private readonly Context context;

        public SqlBeanRepository(Context context)
        {
            this.context = context;
        }

        public async Task<string> CreateBeanAsync(Bean bean)
        {
            await using (this.context)
            {
                await this.context.Beans.AddAsync(bean);
                await this.context.SaveChangesAsync();

                return this.context.Beans.FirstOrDefault(b => b.Id == bean.Id).Id;
            }
        }

        public async Task CreateBeansAsync(List<Bean> beans)
        {
            await using (this.context)
            {
                await this.context.Beans.AddRangeAsync(beans);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task UpdateBeanAsync(Bean bean)
        {
            await using (this.context)
            {
                this.context.Beans.UpdateRange(bean);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteBeanAsync(Bean bean)
        {
            await using (this.context)
            {
                this.context.Beans.RemoveRange(bean);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Bean> GetBeanAsync(string id)
        {
            await using (this.context)
            {
                return await this.context.Beans.FirstOrDefaultAsync(b => b.Id == id);
            }
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            await using (this.context)
            {
                return await this.context.Beans.FirstOrDefaultAsync();
            }
        }
    }
}