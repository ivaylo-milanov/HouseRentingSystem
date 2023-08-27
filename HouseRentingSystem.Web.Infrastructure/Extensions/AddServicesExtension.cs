namespace HouseRentingSystem.Web.Infrastructure.Extensions
{
    using HouseRentingSystem.Services.Data;
    using HouseRentingSystem.Services.Data.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public static class AddServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IAgentService, AgentService>();

            return services;
        }
    }
}
