using System.Threading.Tasks;
using Arkhi.FTGO.OrderHistoryService.Domain.Entities;
using Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces;
using Arkhi.FTGO.OrderService.Domain.Events;
using AutoMapper;
using MassTransit;

namespace Arkhi.FTGO.OrderHistoryService.Application.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IOrderHistoryService _service;

        public OrderCreatedConsumer(IOrderHistoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var entity = _mapper.Map<OrderHistory>(context.Message);
            _service.HandleNewOrder(entity);

            return Task.CompletedTask;
        }
    }
}