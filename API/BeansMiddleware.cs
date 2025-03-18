using Data.Entities;
using Data.Persistence.Repository.Interfaces;
using Domain.Logic;

namespace API
{
    public class BeansMiddleware
    {
        private readonly IBeansRepository beansRepository;

        private readonly IBOTDRepository botdRepository;

        public BeansMiddleware(IBeansRepository beansRepository, IBOTDRepository botdRepository)
        {
            this.beansRepository = beansRepository;
            this.botdRepository = botdRepository;
        }

        public async Task RunAsync()
        {
            var beans = await new ReadBeansFile().ReadBeansFileAsync();  

            var dataBeans = beans.Select(s => s.ToDataEntity()).ToList();
            
            foreach(var bean in dataBeans)
            {
                bean.Details.Id = Guid.NewGuid().ToString();
                bean.Price.Id = Guid.NewGuid().ToString();
            }
            await this.beansRepository.CreateBeansAsync(dataBeans);

            await this.botdRepository.CreateBOTDAsync(new BOTD { Id = Guid.NewGuid().ToString(), BeanId = beans.First(b => b.IsBOTD).Id, DateTime = DateTimeOffset.Now.AddDays(1).Date });  
        }    
    }

}