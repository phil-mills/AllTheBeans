using Data.Entities;

namespace Data.Persistence.Repository.Interfaces
{
    public interface IBeansRepository
    {
        public Task CreateBeansAsync(List<Bean> beans);

        public Task<Bean> GetBeanOfTheDayAsync();
    }
}