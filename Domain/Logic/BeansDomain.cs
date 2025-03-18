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
            var dataBean = bean.ToDataEntity();
            dataBean.Details.Id = Guid.NewGuid().ToString();
            dataBean.Price.Id = Guid.NewGuid().ToString();

            var beanId = await this.beansRepository.CreateBeanAsync(dataBean);

            if (beanId != null)
            {
                return beanId;
            }

            return null;
        }

        public async Task<string> UpdateBeanAsync(Bean bean)
        {
            var beanId = await this.beansRepository.UpdateBeanAsync(bean.ToDataEntity());

            if (beanId != null)
            {
                return beanId;
            }

            return null;
        }

        public async Task<bool> DeleteBeanAsync(string id)
        {
            return await this.beansRepository.DeleteBeanAsync(id);
        }

        public async Task<Bean> GetBeanAsync(string id)
        {
            var bean = await this.beansRepository.GetBeanAsync(id);

            if (bean == null)
            {
                return null;
            }

            return new Bean().FromDataEntity(bean);
        }

        public async Task<IEnumerable<Bean>> GetAllBeanAsync(string[] filters = null)
        {
            var beans = await this.beansRepository.GetAllBeansAsync();

            return beans.Select(bean => new Bean().FromDataEntity(bean));
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            var bean = await this.beansRepository.GetBeanOfTheDayAsync();

            return new Bean().FromDataEntity(bean);
        }
    }
}