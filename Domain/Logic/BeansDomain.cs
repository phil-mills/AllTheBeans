using Data.Persistence.Repository.Interfaces;
using Domain.Entities;
using Domain.Logic.Interfaces;

namespace Domain.Logic
{
    public class BeansDomain : IBeansDomain
    {
        private readonly IBeansRepository beansRepository;

        public BeansDomain(IBeansRepository beansRepository)
        {
            this.beansRepository = beansRepository;
        }

        public async Task<string> CreateBeanAsync(Bean bean)
        {
            return await this.beansRepository.CreateBeanAsync(bean.ToDataBeans());
        }

        public async Task UpdateBeanAsync(Bean bean)
        {
            await this.beansRepository.UpdateBeanAsync(bean.ToDataBeans());
        }

        public async Task<bool> DeleteBeanAsync(string id)
        {
            return await this.beansRepository.DeleteBeanAsync(id);
        }

        public async Task<Bean> GetBeanAsync(string id)
        {
            var bean = await this.beansRepository.GetBeanAsync(id);

            return new Bean().FromDataBeans(bean);
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            var bean = await this.beansRepository.GetBeanOfTheDayAsync();

            return new Bean().FromDataBeans(bean);
        }
    }
}