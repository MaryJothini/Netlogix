using System;
using Microsoft.EntityFrameworkCore;
using NTG.ShipmentManagement.Domain;
using NTG.ShipmentManagement.Domain.ShipmentRequest;

namespace NTG.ShipmentManagement.Persistence
{
    public class ShipmentRequestDbContext : DbContext
    {
        public ShipmentRequestDbContext(DbContextOptions<ShipmentRequestDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShipmentRequestDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<ShipmentOrder> ShipmentOrders { get; set; }

        public DbSet<ShipmentOrderItem> ShipmentOrderItems { get; set; }
    }
}

