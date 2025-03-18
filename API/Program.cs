using API;
using Data.Persistence;
using Data.Persistence.Repository;
using Data.Persistence.Repository.Interfaces;
using Domain.Logic;
using Domain.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase("AllTheBeans"));
builder.Services.AddScoped<IBeansRepository, SqlBeanRepository>();
builder.Services.AddScoped<IBeansDomain, BeansDomain>();
builder.Services.AddScoped<IBOTDRepository, BOTDRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async () => 
{
    using (var scope = app.Services.CreateScope())
    {
        var beansRepository = scope.ServiceProvider.GetRequiredService<IBeansRepository>();
        var botdRepository = scope.ServiceProvider.GetRequiredService<IBOTDRepository>();
        await new BeansMiddleware(beansRepository, botdRepository).RunAsync();
        await new BOTDMiddleware(beansRepository, botdRepository).RunAsync();
    }
});

app.Run();
