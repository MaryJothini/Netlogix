using System;
using Microsoft.EntityFrameworkCore;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;
using NTG.ShipmentManagement.Domain.ShipmentRequest;

namespace NTG.ShipmentManagement.Persistence.Repositories
{
    public class ShipmentOrderRepository : GenericRepository<ShipmentOrder>, IShipmentOrderRepository
    {
        private readonly ShipmentRequestDbContext dbContext;
        public ShipmentOrderRepository(ShipmentRequestDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ShipmentOrder> GetByOrderId(string orderId, CancellationToken cancellationToken)
        {
            return await GetFullQuery().FirstOrDefaultAsync(o => o.OrdetId == orderId, cancellationToken);
        }

        public async Task<List<ShipmentOrder>> GetAllWithDetail(CancellationToken cancellationToken)
        {
            return await GetFullQuery()
                  .ToListAsync(cancellationToken);
        }

        public async Task<bool> OrderIdExists(string orderId)
        {
            var entity = await this.dbContext.ShipmentOrders.FirstOrDefaultAsync(o => o.OrdetId == orderId);
            return entity != null;
        }


        private IQueryable<ShipmentOrder> GetFullQuery()
        {
            return this.dbContext.ShipmentOrders
                .Include(o => o.DeliveryAddress)
                 .Include(o => o.PickupAddress)
                  .Include(o => o.ShipmentOrderItems);
        }
    }
}

