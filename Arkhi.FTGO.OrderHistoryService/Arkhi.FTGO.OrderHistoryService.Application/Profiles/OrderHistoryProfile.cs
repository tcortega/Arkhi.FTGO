using Arkhi.FTGO.Libs.Common.Enums;
using Arkhi.FTGO.OrderHistoryService.Application.Dtos.Responses;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities.Enums;
using Arkhi.FTGO.OrderService.Domain.Events;
using AutoMapper;

namespace Arkhi.FTGO.OrderHistoryService.Application.Profiles
{
    public class OrderHistoryProfile : Profile
    {
        public OrderHistoryProfile()
        {
            CreateMap<OrderHistoryStatus, EnumValue>().ConvertUsing(src => src.GetValue());

            CreateMap<OrderHistory, OrderHistoryResponse>();
            CreateMap<OrderItemHistory, OrderItemHistoryResponse>();

            CreateMap<OrderCreatedEvent, OrderHistory>();
            CreateMap<OrderItemCreatedEvent, OrderItemHistory>()
                .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}