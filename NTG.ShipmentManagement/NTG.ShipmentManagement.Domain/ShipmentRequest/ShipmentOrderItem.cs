using System.ComponentModel.DataAnnotations.Schema;

namespace NTG.ShipmentManagement.Domain.ShipmentRequest
{
    [Table(nameof(ShipmentOrderItem))]
    public class ShipmentOrderItem : BaseEntity
    {
        public ShipmentOrderItem(string itemCode, int quantity)
        {
            ItemCode = itemCode;
            Quantity = quantity;
        }


        private ShipmentOrderItem()
        {

        }
        
        public string ItemCode { get; protected set; }

        public int Quantity { get; protected set; }
    }
}

