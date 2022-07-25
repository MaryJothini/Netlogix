using AutoMapper;
using NTG.ShipmentManagement.Applicaiton.BaseDtos;
using NTG.ShipmentManagement.Applicaiton.Feature.ShipmentReqest;
using NTG.ShipmentManagement.Domain.ShipmentRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTG.ShipmentManagement.Applicaiton.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<ShipmentOrderCreateDto, ShipmentOrder>().ReverseMap();
            CreateMap<ShipmentItemDto, ShipmentOrderItem>().ReverseMap();
            CreateMap<AddressDto, DeliveryAddress>().ReverseMap();
            CreateMap<AddressDto, PickupAddress>().ReverseMap();
            CreateMap<ShipmentOrderDto, ShipmentOrder>().ReverseMap(); 

        }
    }
}
