using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces;
using MassTransit;

namespace Arkhi.FTGO.OrderHistoryService.Application.Consumers
{
    public class KitchenFinishedConsumer : IConsumer<KitchenFinishedEvent>
    {
        private readonly IOrderHistoryService _service;

        public KitchenFinishedConsumer(IOrderHistoryService service)
        {
            _service = service;
        }

        public Task Consume(ConsumeContext<KitchenFinishedEvent> context)
        {
            _service.HandleKitchenFinishedEvent(context.Message);
            return Task.CompletedTask;
        }
    }
}