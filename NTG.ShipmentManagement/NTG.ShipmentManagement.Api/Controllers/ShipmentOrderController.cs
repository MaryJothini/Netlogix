using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTG.ShipmentManagement.Api.ViewModel;
using NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest;
using NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Commands;
using NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Queries;
using NTG.ShipmentManagement.Applicaiton.Responses;

namespace NTG.ShipmentManagement.Api.Controllers
{
    [Route("api/shipmentOrders")]
    [ApiController]
    public class ShipmentOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ShipmentOrderDto>>> Get(CancellationToken cancellationToken)
        {
            var leaveAllocations = await _mediator.Send(new GetAllShipmentOdersRequest(), cancellationToken);
            return Ok(leaveAllocations);
        }

        [HttpGet("{orderId}")]
        [Authorize]
        public async Task<ActionResult<ShipmentOrderDto>> Get(string orderId, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _mediator.Send(new GetShipmentOderByIdRequest { OrdetId = orderId }, cancellationToken);
            return Ok(leaveAllocation);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Post(string order)
        {
            var command = new CreateShipmentOrderCommand { ShipmentOrderJson = order };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

    }
}
