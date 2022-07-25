using MediatR;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Queries
{
    public class GetShipmentOderByIdRequest : IRequest<ShipmentOrderDto>
    {
        public string OrdetId { get; set; }
    }
}
