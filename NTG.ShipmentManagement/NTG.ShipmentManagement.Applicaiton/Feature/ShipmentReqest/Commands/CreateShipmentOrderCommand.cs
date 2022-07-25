using MediatR;
using NTG.ShipmentManagement.Applicaiton.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Commands
{
    public class CreateShipmentOrderCommand : IRequest<BaseCommandResponse>
    {
        public string ShipmentOrderJson { get; set; }
    }
}
