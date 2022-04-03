using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Domain.Services.Interfaces;
using Arkhi.FTGO.KitchenService.Domain.Events;
using MassTransit;

namespace Arkhi.FTGO.DeliveryService.Application.Consumers
{
    public class KitchenFinishedConsumer : IConsumer<KitchenFinishedEvent>
    {
        private readonly IDeliveryService _service;

        public KitchenFinishedConsumer(IDeliveryService service)
        {
            _service = service;
        }

        public async Task Consume(ConsumeContext<KitchenFinishedEvent> context)
        {
            await _service.HandleDelivery(context.Message);
        }
    }
}