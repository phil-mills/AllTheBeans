using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class Context : DbContext
    {
         public DbSet<Bean> Beans { get; set; } 

        public Context(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseInMemoryDatabase("AllTheBeans"); 
            base.OnConfiguring(optionsBuilder);
        } 
    }
}