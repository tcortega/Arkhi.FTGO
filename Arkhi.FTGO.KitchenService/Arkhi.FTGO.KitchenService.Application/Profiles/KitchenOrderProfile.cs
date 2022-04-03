using Arkhi.FTGO.KitchenService.Application.Dtos.Responses;
using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Entities.Enums;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.Libs.Common.Enums;
using Arkhi.FTGO.OrderService.Domain.Events;
using AutoMapper;

namespace Arkhi.FTGO.KitchenService.Application.Profiles
{
    public class KitchenOrderProfile : Profile
    {
        public KitchenOrderProfile()
        {
            CreateMap<KitchenOrderStatus, EnumValue>()
                .ConvertUsing(src => src.GetValue());

            CreateMap<KitchenOrder, KitchenOrderResponse>();
            CreateMap<KitchenOrderItem, KitchenOrderItemResponse>();

            // Events
            CreateMap<OrderCreatedEvent, KitchenOrder>();
            CreateMap<OrderItemCreatedEvent, KitchenOrderItem>();
        }
    }
}