using System.ComponentModel.DataAnnotations.Schema;

namespace NTG.ShipmentManagement.Domain
{
    [Table(nameof(Address))]
    public class Address : BaseEntity
    {
        public Address(string unit, string street, string suburb, string city, string postcode)
        {
            Unit = unit;
            Street = street;
            Suburb = suburb;
            City = city;
            Postcode = postcode;
        }

        private Address()
        {

        }

        public string Unit { get; protected set; }

        public string Street { get; protected set; }

        public string Suburb { get; protected set; }

        public string City { get; protected set; }

        public string Postcode { get; protected set; }

    }
}

