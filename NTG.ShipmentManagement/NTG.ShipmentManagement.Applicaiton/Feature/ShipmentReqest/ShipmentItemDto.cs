using Newtonsoft.Json;
using NTG.ShipmentManagement.Applicaiton.BaseDtos;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest
{
    public class ShipmentItemDto
    {
        [JsonProperty("ItemCode")]
        public string ItemCode { get; protected set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; protected set; }
    }
}
