using Domain.Logic;

namespace API
{
    public class BeansMiddleware
    {
        public async Task Run()
        {
            var beans = await new ReadBeansFile().ReadBeansFileAsync();     
        }    
    }

}