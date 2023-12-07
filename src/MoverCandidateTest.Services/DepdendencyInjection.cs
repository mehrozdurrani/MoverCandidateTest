using Microsoft.Extensions.DependencyInjection;
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
    }
}