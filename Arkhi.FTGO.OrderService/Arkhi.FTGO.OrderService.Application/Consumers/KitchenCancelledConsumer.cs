using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.OrderService.Domain.Services.Interfaces;
using MassTransit;

namespace Arkhi.FTGO.OrderService.Application.Consumers
{
    public class KitchenCancelledConsumer : IConsumer<KitchenCancelledEvent>
    {
        private readonly IOrderService _service;

        public KitchenCancelledConsumer(IOrderService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<KitchenCancelledEvent> context)
        {
            await _service.HandleOrderCancelledEvent(context.Message.OrderId);
        }
    }
}