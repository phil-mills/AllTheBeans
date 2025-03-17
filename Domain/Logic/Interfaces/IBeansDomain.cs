using Domain.Entities;

namespace Domain.Logic.Interfaces
{
    public interface IBeansDomain
    {
        public Task<string> CreateBeanAsync(Bean bean);

        public Task UpdateBeanAsync(Bean bean);

        public Task DeleteBeanAsync(Bean bean);

        public Task<Bean> GetBeanAsync(string id);

        public Task<Bean> GetBeanOfTheDayAsync();
    }
}