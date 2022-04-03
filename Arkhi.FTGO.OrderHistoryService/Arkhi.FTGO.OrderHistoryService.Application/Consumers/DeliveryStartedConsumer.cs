using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Domain.Events;
using Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces;
using MassTransit;

namespace Arkhi.FTGO.OrderHistoryService.Application.Consumers
{
    public class DeliveryStartedConsumer : IConsumer<DeliveryStartedEvent>
    {
        private readonly IOrderHistoryService _service;

        public DeliveryStartedConsumer(IOrderHistoryService service)
        {
            _service = service;
        }

        public Task Consume(ConsumeContext<DeliveryStartedEvent> context)
        {
            _service.HandleDeliveryStartedEvent(context.Message);
            return Task.CompletedTask;
        }
    }
}