using Data.Persistence.Repository;
using Data.Persistence.Repository.Interfaces;

namespace API
{
    public class BOTDMiddleware
    {
        private readonly IBeansRepository beansRepository;

        private readonly IBOTDRepository botdRepository;

        public BOTDMiddleware(IBeansRepository beansRepository, IBOTDRepository botdRepository)
        {
            this.beansRepository = beansRepository;
            this.botdRepository = botdRepository;
        }

        public async Task RunAsync()
        {
            var botd = await this.botdRepository.GetBOTDAsync();

            if (botd.DateTime >= DateTime.Now)
            {
                var bean = await this.beansRepository.GetBeanAsync(botd.BeanId);

                var beans = await this.beansRepository.GetAllBeansAsync();

                var newBOTD = beans.FirstOrDefault(b => b.Index == bean.Index + 1);
                
                bean.IsBOTD = false;
                newBOTD.IsBOTD = true;

                botd.BeanId = newBOTD.Id;
                botd.DateTime = DateTime.Now.Date.AddDays(1);

                await this.beansRepository.UpdateBeanAsync(bean);
                await this.botdRepository.UpdateBOTDAsync(botd);
            }
        }
    }
}