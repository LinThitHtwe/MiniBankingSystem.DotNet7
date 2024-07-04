using MiniBankingSystem.BusinessLogic.Features.Account;
using MiniBankingSystem.BusinessLogic.Features.State;
using MiniBankingSystem.BusinessLogic.Features.Township;
using MiniBankingSystem.BusinessLogic.Features.Transactions;
using MiniBankingSystem.DataAccess.Services.Account;
using MiniBankingSystem.DataAccess.Services.State;
using MiniBankingSystem.DataAccess.Services.Township;
using MiniBankingSystem.DataAccess.Services.TransactionHistory;
using MiniBankingSystem.Utils.Helpers;

namespace MiniBankingSystem.API
{
    public static class ModularService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDataAccessServices();
            services.AddBusinessLogicServices();
            return services;
        }

        private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<StateDataAccess>();
            services.AddScoped<TownshipDataAccess>();
            services.AddScoped<AccountDataAccess>();
            services.AddScoped<TransactionHistoryDataAccess>();
            return services;
        }

        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<StateService>();
            services.AddScoped<TownshipService>();
            services.AddScoped<AccountService>();
            services.AddScoped<TransactionService>();
            services.AddScoped<BankActions>();
            return services;
        }
    }
}
