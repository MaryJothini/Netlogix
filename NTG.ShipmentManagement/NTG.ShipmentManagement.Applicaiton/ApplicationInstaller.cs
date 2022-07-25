using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace NTG.ShipmentManagement.Applicaiton
{
    public static class ApplicationInstaller
    {
        public static IServiceCollection InstallApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
