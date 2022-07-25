using System;
using NTG.ShipmentManagement.Domain.ShipmentRequest;

namespace NTG.ShipmentManagement.Applicaiton.Contracts.Persistence
{
    public interface IShipmentOrderRepository : IGenericRepository<ShipmentOrder>
    {
        Task<ShipmentOrder> GetByOrderId(string orderId, CancellationToken cancellationToken);
        Task<List<ShipmentOrder>> GetAllWithDetail(CancellationToken cancellationToken);
        Task<bool> OrderIdExists(string orderId);
    }
}

