using Microsoft.EntityFrameworkCore;
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
builder.Services.AddScoped<AccountDataAccess>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TransactionHistoryDataAccess>();
builder.Services.AddScoped<TransactionService>();

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
