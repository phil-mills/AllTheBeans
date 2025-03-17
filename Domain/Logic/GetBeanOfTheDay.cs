using Data.Persistence.Repository.Interfaces;
using Domain.Entities;
using Domain.Logic.Interfaces;

namespace Domain.Logic
{
    public class GetBeanOfTheDay : IGetBeanOfTheDay
    {
        private readonly IBeansRepository beansRepository;

        public GetBeanOfTheDay(IBeansRepository beansRepository)
        {
            this.beansRepository = beansRepository;
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            var bean = await beansRepository.GetBeanOfTheDayAsync();

            return new Bean().FromDataBeans(bean);
        }
    }
}