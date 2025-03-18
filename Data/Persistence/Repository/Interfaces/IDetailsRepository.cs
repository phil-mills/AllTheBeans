using Data.Entities;

namespace Data.Persistence.Repository.Interfaces
{
    public interface IDetailsRepository
    {
        public Task<string> CreateDetailsAsync(Details details);

        public Task CreateDetailsAsync(IEnumerable<Details> details);

        public Task<string> UpdateDetailsAsync(Details details);

        public Task<bool> DeleteDetailsAsync(string id);

        public Task<Details> GetDetailsByBeanIdAsync(string id);
    }
}