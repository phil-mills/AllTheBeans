using Data.Entities;

namespace Data.Persistence.Repository.Interfaces
{
    public interface IBOTDRepository
    {
        public Task CreateBOTDAsync(BOTD botd);

        public Task UpdateBOTDAsync(BOTD botd);

        public Task<BOTD> GetBOTDAsync();
    }
}