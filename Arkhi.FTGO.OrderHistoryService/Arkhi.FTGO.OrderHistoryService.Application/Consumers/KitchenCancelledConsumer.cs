using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces;
using MassTransit;

namespace Arkhi.FTGO.OrderHistoryService.Application.Consumers
{
    public class KitchenCancelledConsumer : IConsumer<KitchenCancelledEvent>
    {
        private readonly IOrderHistoryService _service;

        public KitchenCancelledConsumer(IOrderHistoryService service)
        {
            _service = service;
        }

        public Task Consume(ConsumeContext<KitchenCancelledEvent> context)
        {
            _service.HandleOrderCancelledEvent(context.Message.OrderId);
            return Task.CompletedTask;
        }
    }
}