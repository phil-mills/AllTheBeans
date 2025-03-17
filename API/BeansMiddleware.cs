using Data.Persistence.Repository.Interfaces;
using Domain.Logic;

namespace API
{
    public class BeansMiddleware
    {
        private readonly IBeansRepository beansRepository;

        public BeansMiddleware(IBeansRepository beansRepository)
        {
            this.beansRepository = beansRepository;
        }

        public async Task Run()
        {
            var beans = await new ReadBeansFile().ReadBeansFileAsync();  
            await beansRepository.CreateBeansAsync(beans.Select(b => b.ToDataBeans()).ToList());
        }    
    }

}