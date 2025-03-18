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
                var beans = await this.beansRepository.GetAllBeansAsync();
                var oldBOTD = beans.FirstOrDefault(b => b.Id == botd.BeanId);

                var newBOTD = beans.FirstOrDefault(b => b.Index == oldBOTD?.Index + 1);

                if (newBOTD == null)
                {
                    newBOTD = beans.FirstOrDefault(b => b.Index == 0);
                }
                
                oldBOTD.IsBOTD = false;
                newBOTD.IsBOTD = true;

                botd.BeanId = newBOTD.Id;
                botd.DateTime = DateTime.Now.Date.AddDays(1);

                await this.beansRepository.UpdateBeanAsync(oldBOTD);
                await this.botdRepository.UpdateBOTDAsync(botd);
            }
        }
    }
}