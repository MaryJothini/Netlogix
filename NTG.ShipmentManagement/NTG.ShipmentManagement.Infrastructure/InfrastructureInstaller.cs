using Microsoft.Extensions.DependencyInjection;
using NTG.ShipmentManagement.Applicaiton.Contracts.JsonValidators;
using System.Reflection;

namespace NTG.ShipmentManagement.Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection InstallInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IJsonParser, JsonParser>();

            return services;
        }
    }
}
