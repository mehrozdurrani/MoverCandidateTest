using Microsoft.Extensions.DependencyInjection;
using MoverCandidateTest.DataAccess.Repositories;

namespace MoverCandidateTest.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddSingleton<IInventoryRepository, InventoryRepository>();
            return services;
        }
    }
}