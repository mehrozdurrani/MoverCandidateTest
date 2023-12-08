using Microsoft.Extensions.DependencyInjection;
using MoverCandidateTest.Services.Inventory;
using MoverCandidateTest.Services.WatchHands;

namespace MoverCandidateTest.Services
{
    public static class DepdendencyInjection
    {
        public static IServiceCollection AddCalculateLeastAngleService(this IServiceCollection services)
        {
            services.AddScoped<ICalculateLeastAngleService, CalculateLeastAngleService>();
            return services;
        }
        public static IServiceCollection AddInventoryService(this IServiceCollection services)
        {
            services.AddScoped<IInventoryService, InventoryService>();
            return services;
        }
    }
}