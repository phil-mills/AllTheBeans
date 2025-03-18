using Data.Entities;

namespace Data.Persistence.Repository.Interfaces
{
    public interface IBeansRepository
    {
        public Task<string> CreateBeanAsync(Bean beans);

        public Task CreateBeansAsync(List<Bean> beans);

        public Task UpdateBeanAsync(Bean bean);

        public Task<bool> DeleteBeanAsync(string id);

        public Task<Bean> GetBeanAsync(string id);

        public Task<Bean> GetBeanOfTheDayAsync();
    }
}