using Data.Entities;

namespace Data.Persistence.Repository.Interfaces
{
    public interface IBeansRepository
    {
        public Task<string> CreateBeanAsync(Bean beans);

        public Task CreateBeansAsync(IEnumerable<Bean> beans);

        public Task<string> UpdateBeanAsync(Bean bean);

        public Task<bool> DeleteBeanAsync(string id);

        public Task<Bean> GetBeanAsync(string id);

        public Task<IEnumerable<Bean>> GetAllBeansAsync();

        public Task<Bean> GetBeanOfTheDayAsync();
    }
}