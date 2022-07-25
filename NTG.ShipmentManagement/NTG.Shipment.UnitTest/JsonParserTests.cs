using NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest;
using NTG.ShipmentManagement.Infrastructure;

namespace NTG.Shipment.UnitTest
{
    public class JsonParserTests
    {
     

        [Test]
        public void Given_Json_Is_Valid()
        {
            string givenJson = "{ \"OrderId\": \"CH - 1000\", \"RequestedPickupTime\" : \"2022-07-02 07:30:00\", \"PickupAddress\": { \"Unit\": \"14\", \"Street\": \"Happy Valley Road\", \"Suburb\": \"Sunshine Place\", \"City\": \"Springfield\", \"Postcode\": \"1023\" }, \"DeliveryAddress\": { \"Unit\": \"66\", \"Street\": \"Over the hill street\", \"Suburb\": \"Mountaintop Place\", \"City\": \"Shelbyville\", \"Postcode\": \"2013\" }, \"Items\": [ { \"ItemCode\": \"AMZ - 01\", \"Quantity\": 20 }, { \"ItemCode\": \"XYZ - 02\", \"Quantity\": 5 } ], \"PickupInstructions\": \"Test\", \"DeliveryInstructions\": \"Test\"}";
            var parser = new JsonParser();
            var errors = parser.ValidateJsonShema<ShipmentOrderCreateDto>(givenJson);
            Assert.IsNotNull(errors);
            Assert.AreEqual(errors.Count, 0);
        }

        [Test]
        public void Given_Json_Is_Missing_RequestedPickupTime()
        {
            string givenJson = "{ \"OrderId\": \"CH - 1000\", \"PickupAddress\": { \"Unit\": \"14\", \"Street\": \"Happy Valley Road\", \"Suburb\": \"Sunshine Place\", \"City\": \"Springfield\", \"Postcode\": \"1023\" }, \"DeliveryAddress\": { \"Unit\": \"66\", \"Street\": \"Over the hill street\", \"Suburb\": \"Mountaintop Place\", \"City\": \"Shelbyville\", \"Postcode\": \"2013\" }, \"Items\": [ { \"ItemCode\": \"AMZ - 01\", \"Quantity\": 20 }, { \"ItemCode\": \"XYZ - 02\", \"Quantity\": 5 } ], \"PickupInstructions\": \"Test\", \"DeliveryInstructions\": \"Test\"}";
            var parser = new JsonParser();
            var errors = parser.ValidateJsonShema<ShipmentOrderCreateDto>(givenJson);
            Assert.IsNotNull(errors);
            Assert.AreEqual(errors.Count, 1);
            Assert.IsTrue(errors[0].Message.Contains("RequestedPickupTime"));
        }
    }
}