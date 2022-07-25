namespace NTG.ShipmentManagement.Domain
{
    public class BaseEntity
    {
        public int Id { get; private set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

