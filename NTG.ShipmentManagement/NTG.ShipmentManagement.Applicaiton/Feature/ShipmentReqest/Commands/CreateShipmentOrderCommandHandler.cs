using AutoMapper;
using MediatR;
using NTG.ShipmentManagement.Applicaiton.Contracts.JsonValidators;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;
using NTG.ShipmentManagement.Applicaiton.Exceptions;
using NTG.ShipmentManagement.Applicaiton.Responses;
using NTG.ShipmentManagement.Domain.ShipmentRequest;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Commands
{
    internal class CreateShipmentOrderCommandHandler : IRequestHandler<CreateShipmentOrderCommand, BaseCommandResponse>
    {
        private readonly IJsonParser jsonParser;
        private readonly IMapper _mapper;
        private readonly IShipmentOrderRepository shipmentOrderRepository;

        public CreateShipmentOrderCommandHandler(IJsonParser jsonParser, IMapper mapper, IShipmentOrderRepository shipmentOrderRepository)
        {
            this.jsonParser = jsonParser;
            _mapper = mapper;
            this.shipmentOrderRepository = shipmentOrderRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateShipmentOrderCommand request, CancellationToken cancellationToken)
        {
            var validationErrors = this.jsonParser.ValidateJsonShema<ShipmentOrderCreateDto>(request.ShipmentOrderJson);
            if(validationErrors.Count > 0)
            {
                throw new ValidationException(validationErrors.Select(s => s.Message).ToList());
            }

            var data = this.jsonParser.GetData<ShipmentOrderCreateDto>(request.ShipmentOrderJson);
            if (data == null)
            {
                throw new ValidationException(new[] { "Invalid data. Please check the playload" }.ToList());
            }


            var response = new BaseCommandResponse();
            var validator = new ShipmentOderValidator(this.shipmentOrderRepository);

            var validationResult = await validator.ValidateAsync(data);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Order creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }else
            {
                var entity = _mapper.Map<ShipmentOrder>(data);
                if (entity == null)
                {
                    throw new ValidationException(new[] { "Invalid mapping" }.ToList());
                }

                await this.shipmentOrderRepository.AddAsync(entity);
                await this.shipmentOrderRepository.SaveAsync();
                response.Id = entity.Id;
                response.Success = true;
                response.Message = "Order creation Successful";
            }

            

            return response;
        }
    }
}
