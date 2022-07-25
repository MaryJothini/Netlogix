using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTG.ShipmentManagement.Domain.ShipmentRequest
{
    [Table(nameof(ShipmentOrder))]
    public class ShipmentOrder : BaseEntity
    {
        public ShipmentOrder(string ordetId, DateTime requestedPickupTime, string? pickupInstruction, string? deliveryInstruction)
        {
            OrdetId = ordetId;
            RequestedPickupTime = requestedPickupTime;
            PickupInstruction = pickupInstruction;
            DeliveryInstruction = deliveryInstruction;
        }

        private ShipmentOrder()
        {

        }

        public string OrdetId { get; protected set; }

        public DateTime RequestedPickupTime { get; protected set; }

        public virtual PickupAddress PickupAddress { get; protected set; }

        public virtual DeliveryAddress DeliveryAddress { get; protected set; }

        public virtual ICollection<ShipmentOrderItem> ShipmentOrderItems { get; protected set; }

        public string? PickupInstruction { get; protected set; }

        public string? DeliveryInstruction { get; protected set; }

        
    }
}

