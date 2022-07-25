using Newtonsoft.Json;

namespace NTG.ShipmentManagement.Applicaiton.BaseDtos
{
    public class AddressDto
    {
        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("Suburb")]
        public string Suburb { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Postcode")]
        public string Postcode { get; set; }
    }
}
