using AutoMapper;
using MediatR;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Queries
{
    public class GetShipmentOderByIdRequestHandler : IRequestHandler<GetShipmentOderByIdRequest, ShipmentOrderDto>
    {
        private readonly IMapper _mapper;
        private readonly IShipmentOrderRepository shipmentOrderRepository;

        public GetShipmentOderByIdRequestHandler(IMapper mapper, IShipmentOrderRepository shipmentOrderRepository)
        {
            _mapper = mapper;
            this.shipmentOrderRepository = shipmentOrderRepository;
        }

        public async Task<ShipmentOrderDto> Handle(GetShipmentOderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await this.shipmentOrderRepository.GetByOrderId(request.OrdetId, cancellationToken);
            var dto = this._mapper.Map<ShipmentOrderDto>(order);

            return dto;
        }
    }
}
