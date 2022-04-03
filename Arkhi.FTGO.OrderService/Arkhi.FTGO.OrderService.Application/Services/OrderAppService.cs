using System.Threading.Tasks;
using Arkhi.FTGO.Libs.Infra.Transactions;
using Arkhi.FTGO.OrderService.Application.Dtos.Requests;
using Arkhi.FTGO.OrderService.Application.Dtos.Responses;
using Arkhi.FTGO.OrderService.Application.Services.Interfaces;
using Arkhi.FTGO.OrderService.Domain.Commands;
using Arkhi.FTGO.OrderService.Domain.Entities;
using Arkhi.FTGO.OrderService.Domain.Events;
using Arkhi.FTGO.OrderService.Domain.Repositories;
using Arkhi.FTGO.OrderService.Domain.Services.Interfaces;
using AutoMapper;
using MassTransit;

namespace Arkhi.FTGO.OrderService.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;
        private readonly IPublishEndpoint _publisher;
        private readonly IUnitOfWork _unitOfWork;

        public OrderAppService(IOrderService orderService, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper,
            IPublishEndpoint publisher)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publisher = publisher;
        }

        public OrderResponse GetById(int id)
        {
            var order = _orderService.Validate(id);

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse> Add(OrderRequest request)
        {
            var command = _mapper.Map<CreateNewOrderCommand>(request);

            var order = await _orderService.Add(command);
            _unitOfWork.Commit();

            await PublishNewOrder(order);

            return _mapper.Map<OrderResponse>(order);
        }

        private async Task PublishNewOrder(Order order)
        {
            await _publisher.Publish<OrderCreatedEvent>(new
            {
                OrderId = order.Id,
                order.CustomerId,
                order.Items,
                order.Total
            });
        }
    }
}