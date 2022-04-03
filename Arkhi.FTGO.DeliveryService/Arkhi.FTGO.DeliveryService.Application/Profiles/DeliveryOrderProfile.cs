using Arkhi.FTGO.DeliveryService.Application.Dtos.Responses;
using Arkhi.FTGO.DeliveryService.Domain.Entities;
using Arkhi.FTGO.DeliveryService.Domain.Entities.Enums;
using Arkhi.FTGO.Libs.Common.Enums;
using AutoMapper;

namespace Arkhi.FTGO.DeliveryService.Application.Profiles
{
    public class DeliveryOrderProfile : Profile
    {
        public DeliveryOrderProfile()
        {
            CreateMap<DeliveryOrderStatus, EnumValue>().ConvertUsing(src => src.GetValue());
            CreateMap<DeliveryOrder, DeliveryOrderResponse>();
        }
    }
}