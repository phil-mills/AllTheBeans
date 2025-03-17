using Domain.Entities;

namespace Domain.Logic.Interfaces
{
    public interface IGetBeanOfTheDay
    {
        public Task<Bean> GetBeanOfTheDayAsync();
    }
}