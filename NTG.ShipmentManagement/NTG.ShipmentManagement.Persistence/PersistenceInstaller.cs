using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;
using NTG.ShipmentManagement.Persistence.Repositories;

namespace NTG.ShipmentManagement.Persistence
{
    public static class PersistenceInstaller
    {
        public static IServiceCollection InstallPersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShipmentRequestDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("ShipmentConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IShipmentOrderRepository, ShipmentOrderRepository>();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Review the FormMain Singleton.
                var context = serviceProvider.GetRequiredService<ShipmentRequestDbContext>();
                context.Database.Migrate();
            }           
            return services;
        }
    }
}
