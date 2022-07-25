using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTG.ShipmentManagement.Applicaiton.Models;
using NTG.ShipmentManagement.Applicaiton.Contracts.Authentication;
using NTG.ShipmentManagement.Identity.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NTG.ShipmentManagement.Identity
{
    public static class IdentityInstaller
    {
        public static IServiceCollection InstallIdentityPersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));

            services.AddDbContext<ShipmentOrderIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ShipmentConnectionString"),
                m => m.MigrationsAssembly(typeof(ShipmentOrderIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ShipmentOrderIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthenticatinService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["AuthSettings:Issuer"],
                        ValidAudience = configuration["AuthSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]))
                    };
                });


            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Review the FormMain Singleton.
                var context = serviceProvider.GetRequiredService<ShipmentOrderIdentityDbContext>();
                context.Database.Migrate();
            }

            return services;
        }
     }
}
