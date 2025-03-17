namespace API.Controllers.Entities
{
    public class Bean
    {
        public Domain.Entities.Bean ToDomainBean()
        {
            return new Domain.Entities.Bean();
        }
    }
}