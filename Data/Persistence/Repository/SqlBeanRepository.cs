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
            await this.context.Beans.AddAsync(bean);
            await this.context.SaveChangesAsync();

            return (await this.GetBeanAsync(bean.Id)).Id;
        }

        public async Task CreateBeansAsync(IEnumerable<Bean> beans)
        {
            await this.context.Beans.AddRangeAsync(beans);
            await this.context.SaveChangesAsync();
        }

        public async Task<string> UpdateBeanAsync(Bean bean)
        {
            var existingBean = await this.context.Beans.FindAsync(bean.Id);

            if (existingBean != null)
            {
                this.context.Entry(existingBean).CurrentValues.SetValues(bean);
            }
            else
            {
                await this.context.Beans.AddAsync(bean);
            }
            
            await this.context.SaveChangesAsync();

            return (await this.GetBeanAsync(bean.Id)).Id;
        }

        public async Task<bool> DeleteBeanAsync(string id)
        {
            var bean = await this.GetBeanAsync(id);
            
            if (bean != null)
            {
                this.context.Beans.Remove(bean);
                await this.context.SaveChangesAsync();
                
                return true;
            }

            return false;
        }

        public async Task<Bean> GetBeanAsync(string id)
        {
            var bean = await this.context.Beans
            .Include(b => b.Price)
            .Include(b => b.Details)
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();

            return bean;
        }

        public async Task<IEnumerable<Bean>> GetAllBeansAsync()
        {
            var beans = await this.context.Beans
            .Include(b => b.Price)
            .Include(b => b.Details)
            .ToListAsync();

            return beans;
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            var bean = await this.context.Beans
            .Include(b => b.Price)
            .Include(b => b.Details)
            .Where(b => b.IsBOTD == true)
            .FirstOrDefaultAsync();

            return bean;
        }
    }
}