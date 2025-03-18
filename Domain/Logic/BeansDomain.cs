using Data.Persistence.Repository.Interfaces;
using Domain.Entities;
using Domain.Logic.Interfaces;

namespace Domain.Logic
{
    public class BeansDomain : IBeansDomain
    {
        private readonly IBeansRepository beansRepository;

        private readonly IPricesRepository pricesRepository;
        
        private readonly IDetailsRepository detailsRepository;

        public BeansDomain(IBeansRepository beansRepository, IPricesRepository pricesRepository, IDetailsRepository detailsRepository)
        {
            this.beansRepository = beansRepository;
            this.pricesRepository = pricesRepository;
            this.detailsRepository = detailsRepository;
        }

        public async Task<string> CreateBeanAsync(Bean bean)
        {
            var beanId = await this.beansRepository.CreateBeanAsync(bean.ToDataBeans());

            var priceId = await this.pricesRepository.CreatePriceAsync(bean.ToDataPrice());

            var detailsId = await this.detailsRepository.CreateDetailsAsync(bean.ToDataDetails());

            if (beanId != null && priceId != null && detailsId != null)
            {
                return beanId;
            }

            return null;
        }

        public async Task<string> UpdateBeanAsync(Bean bean)
        {
            var beanId = await this.beansRepository.UpdateBeanAsync(bean.ToDataBeans());

            var priceId = await this.pricesRepository.UpdatePriceAsync(bean.ToDataPrice());

            var detailsId = await this.detailsRepository.UpdateDetailsAsync(bean.ToDataDetails());

            if (beanId != null && priceId != null && detailsId != null)
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

            var price = await this.pricesRepository.GetPriceByBeanIdAsync(bean.Id);
            
            if (price == null)
            {
                return null;
            }

            var details = await this.detailsRepository.GetDetailsByBeanIdAsync(bean.Id);

            if (details == null)
            {
                return null;
            }

            return new Bean().FromDataEntities(bean, price, details);
        }

        public async Task<Bean> GetBeanOfTheDayAsync()
        {
            var bean = await this.beansRepository.GetBeanOfTheDayAsync();

            if (bean == null)
            {
                return null;
            }

            var price = await this.pricesRepository.GetPriceByBeanIdAsync(bean.Id);
            
            if (price == null)
            {
                return null;
            }

            var details = await this.detailsRepository.GetDetailsByBeanIdAsync(bean.Id);

            if (details == null)
            {
                return null;
            }

            return new Bean().FromDataEntities(bean, price, details);
        }
    }
}