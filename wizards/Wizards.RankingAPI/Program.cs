using Microsoft.EntityFrameworkCore;
using Wizards.Core.Interfaces.UserModelInterfaces;
using Wizards.Repository;
using Wizards.Repository.Repository.UserModel;
using Wizards.Repository.ServiceRegistration;
using Wizards.Services.SearchService;
using Wizards.Services.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();

var connectionString = builder.Configuration.GetConnectionString("WizardDatabase");
builder.Services.AddDbContext<WizardsContext>(options => options.UseSqlServer(connectionString));

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

app.Run();