using Microsoft.EntityFrameworkCore;
using MiniBankingSystem.API;
using MiniBankingSystem.API.Exceptions;
using MiniBankingSystem.BusinessLogic.Features.Account;
using MiniBankingSystem.BusinessLogic.Features.State;
using MiniBankingSystem.BusinessLogic.Features.Township;
using MiniBankingSystem.BusinessLogic.Features.Transactions;
using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.DataAccess.Services.Account;
using MiniBankingSystem.DataAccess.Services.State;
using MiniBankingSystem.DataAccess.Services.Township;
using MiniBankingSystem.DataAccess.Services.TransactionHistory;
using MiniBankingSystem.Utils.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddServices();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.CustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
