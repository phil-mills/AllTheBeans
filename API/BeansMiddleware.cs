using Data.Entities;
using Data.Persistence.Repository.Interfaces;
using Domain.Logic;

namespace API
{
    public class BeansMiddleware
    {
        private readonly IBeansRepository beansRepository;
        private readonly IPricesRepository pricesRepository;
        private readonly IDetailsRepository detailsRepository;

        private readonly IBOTDRepository botdRepository;

        public BeansMiddleware(IBeansRepository beansRepository, IPricesRepository pricesRepository, IDetailsRepository detailsRepository, IBOTDRepository botdRepository)
        {
            this.beansRepository = beansRepository;
            this.pricesRepository = pricesRepository;
            this.detailsRepository = detailsRepository;
            this.botdRepository = botdRepository;
        }

        public async Task RunAsync()
        {
            var beans = await new ReadBeansFile().ReadBeansFileAsync();  

            await this.beansRepository.CreateBeansAsync(beans.Select(static s => s.ToDataBeans()));

            await this.pricesRepository.CreatePricesAsync(beans.Select(static s => s.ToDataPrice()));

            await this.detailsRepository.CreateDetailsAsync(beans.Select(static s => s.ToDataDetails()));

            await this.botdRepository.CreateBOTDAsync(new BOTD { Id = Guid.NewGuid().ToString(), BeanId = beans.First(b => b.IsBOTD).Id, DateTime = DateTimeOffset.Now.AddDays(1).Date });  
        }    
    }

}