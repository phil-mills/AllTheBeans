using Data.Persistence.Repository.Interfaces;
using Domain.Logic;

namespace API
{
    public class BeansMiddleware
    {
        private readonly IBeansRepository beansRepository;
        private readonly IPricesRepository pricesRepository;
        private readonly IDetailsRepository detailsRepository;

        public BeansMiddleware(IBeansRepository beansRepository, IPricesRepository pricesRepository, IDetailsRepository detailsRepository)
        {
            this.beansRepository = beansRepository;
            this.pricesRepository = pricesRepository;
            this.detailsRepository = detailsRepository;
        }

        public async Task Run()
        {
            var beans = await new ReadBeansFile().ReadBeansFileAsync();  

            await beansRepository.CreateBeansAsync(beans.Select(static s => s.ToDataBeans()));

            await pricesRepository.CreatePricesAsync(beans.Select(static s => s.ToDataPrice()));

            await detailsRepository.CreateDetailsAsync(beans.Select(static s => s.ToDataDetails()));
        }    
    }

}