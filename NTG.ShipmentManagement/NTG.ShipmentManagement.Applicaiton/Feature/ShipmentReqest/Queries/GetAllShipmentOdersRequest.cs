using AutoMapper;
using MediatR;
using NTG.ShipmentManagement.Applicaiton.Contracts.JsonValidators;
using NTG.ShipmentManagement.Applicaiton.Contracts.Persistence;
using NTG.ShipmentManagement.Applicaiton.Exceptions;
using NTG.ShipmentManagement.Applicaiton.Responses;
using NTG.ShipmentManagement.Domain.ShipmentRequest;
namespace NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest.Queries
{
    public class GetAllShipmentOdersRequest : IRequest<List<ShipmentOrderDto>>
    {
    }
}
