using Arkhi.FTGO.OrderService.Application.Dtos.Requests;
using Arkhi.FTGO.OrderService.Application.Dtos.Responses;
using Arkhi.FTGO.OrderService.Domain.Commands;
using Arkhi.FTGO.OrderService.Domain.Entities;
using AutoMapper;

namespace Arkhi.FTGO.OrderService.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // CreateMap<OrderStatus, EnumValue>().ConvertUsing(src => src.GetValue());
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderItem, OrderItemResponse>();

            CreateMap<OrderItemRequest, CreateNewOrderItemCommand>();
            CreateMap<OrderRequest, CreateNewOrderCommand>();
        }
    }
}