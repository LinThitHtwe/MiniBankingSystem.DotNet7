using Microsoft.EntityFrameworkCore;
using MiniBankingSystem.BusinessLogic.Features.State;
using MiniBankingSystem.BusinessLogic.Features.Township;
using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.DataAccess.Services.State;
using MiniBankingSystem.DataAccess.Services.Township;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<StateDataAccess>();
builder.Services.AddScoped<StateService>(); 
builder.Services.AddScoped<TownshipDataAccess>();
builder.Services.AddScoped<TownshipService>();

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
