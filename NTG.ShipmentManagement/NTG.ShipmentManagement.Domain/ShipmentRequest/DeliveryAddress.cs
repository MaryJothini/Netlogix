using System;
namespace NTG.ShipmentManagement.Domain.ShipmentRequest
{
    public class DeliveryAddress : Address
    {
        public DeliveryAddress(string unit, string street, string suburb, string city, string postcode)
            : base(unit, street, suburb, city, postcode)
        {

        } 
    }
}

