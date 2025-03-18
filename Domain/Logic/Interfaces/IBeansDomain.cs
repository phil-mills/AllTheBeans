using Domain.Entities;

namespace Domain.Logic.Interfaces
{
    public interface IBeansDomain
    {
        public Task<string> CreateBeanAsync(Bean bean);

        public Task<string> UpdateBeanAsync(Bean bean);

        public Task<bool> DeleteBeanAsync(string id);

        public Task<Bean> GetBeanAsync(string id);

        public Task<IEnumerable<Bean>> GetAllBeanAsync(Filters filters);

        public Task<Bean> GetBeanOfTheDayAsync();
    }
}