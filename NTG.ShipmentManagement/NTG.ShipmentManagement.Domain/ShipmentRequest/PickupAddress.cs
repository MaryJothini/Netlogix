using System;
namespace NTG.ShipmentManagement.Domain.ShipmentRequest
{
    public class PickupAddress : Address
    {
       public PickupAddress(string unit, string street, string suburb, string city, string postcode)
            : base(unit, street, suburb, city, postcode)
       {

       }
    }
}

