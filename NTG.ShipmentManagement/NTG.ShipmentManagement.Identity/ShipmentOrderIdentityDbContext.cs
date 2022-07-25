using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTG.ShipmentManagement.Identity.Configuration;

namespace NTG.ShipmentManagement.Identity
{
    public class ShipmentOrderIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public ShipmentOrderIdentityDbContext(DbContextOptions<ShipmentOrderIdentityDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
