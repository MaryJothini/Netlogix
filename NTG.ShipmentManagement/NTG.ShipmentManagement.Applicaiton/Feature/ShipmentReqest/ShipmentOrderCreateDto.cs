using Newtonsoft.Json;
using NTG.ShipmentManagement.Applicaiton.BaseDtos;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest
{
    public class ShipmentOrderCreateDto 
    {
        [JsonProperty("OrderId")]
        public string OrdetId { get; set; }

        [JsonProperty("RequestedPickupTime")]
        public DateTime RequestedPickupTime { get; set; }

        [JsonProperty("PickupAddress")]
        public virtual AddressDto PickupAddress { get; set; }

        [JsonProperty("DeliveryAddress")]
        public virtual AddressDto DeliveryAddress { get; set; }

        [JsonProperty("Items")]
        public virtual ICollection<ShipmentItemDto> ShipmentOrderItems { get; set; }

        [JsonProperty("PickupInstructions")]
        public string? PickupInstruction { get; set; }

        [JsonProperty("DeliveryInstructions")]
        public string? DeliveryInstruction { get; set; }
    }
}
