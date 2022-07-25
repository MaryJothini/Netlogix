using AutoMapper;
using MediatR;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Queries
{
    public class GetAllShipmentOdersRequestHandler : IRequestHandler<GetAllShipmentOdersRequest, List<ShipmentOrderDto>>
    {
        private readonly IMapper _mapper;
        private readonly IShipmentOrderRepository shipmentOrderRepository;

        public GetAllShipmentOdersRequestHandler(IMapper mapper, IShipmentOrderRepository shipmentOrderRepository)
        {
            _mapper = mapper;
            this.shipmentOrderRepository = shipmentOrderRepository;
        }

        public async Task<List<ShipmentOrderDto>> Handle(GetAllShipmentOdersRequest request, CancellationToken cancellationToken)
        {
            var order = await this.shipmentOrderRepository.GetAllWithDetail(cancellationToken);
            var dtos = this._mapper.Map<List<ShipmentOrderDto>>(order);

            return dtos; ;
        }
    }
}
