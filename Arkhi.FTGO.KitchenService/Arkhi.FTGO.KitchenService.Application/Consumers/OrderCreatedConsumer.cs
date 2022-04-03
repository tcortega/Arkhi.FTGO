using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Domain.Entities;
using Arkhi.FTGO.KitchenService.Domain.Services.Interfaces;
using Arkhi.FTGO.OrderService.Domain.Events;
using AutoMapper;
using MassTransit;

namespace Arkhi.FTGO.KitchenService.Application.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IKitchenService _service;

        public OrderCreatedConsumer(IKitchenService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var entity = _mapper.Map<KitchenOrder>(context.Message);
            _service.HandleNewOrder(entity);

            return Task.CompletedTask;
        }
    }
}