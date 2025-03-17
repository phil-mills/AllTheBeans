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

        public async Task CreateBeanAsync(Bean bean)
        {
            await using (context)
            {
                await context.Beans.AddAsync(bean);
                await context.SaveChangesAsync();
            }
        }

        public async Task CreateBeansAsync(List<Bean> beans)
        {
            await using (context)
            {
                await context.Beans.AddRangeAsync(beans);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateBeanAsync(Bean bean)
        {
            await using (context)
            {
                context.Beans.UpdateRange(bean);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteBeansAsync(Bean bean)
        {
            await using (context)
            {
                context.Beans.RemoveRange(bean);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Bean> GetBeanAsync(string id)
        {
            await using (context)
            {
                return await context.Beans.FirstOrDefaultAsync(b => b.Id == id);
            }
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            await using (context)
            {
                return await context.Beans.FirstOrDefaultAsync();
            }
        }
    }
}