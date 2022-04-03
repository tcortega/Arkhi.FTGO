using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Domain.Events;
using Arkhi.FTGO.OrderHistoryService.Domain.Services.Interfaces;
using MassTransit;

namespace Arkhi.FTGO.OrderHistoryService.Application.Consumers
{
    public class DeliveryFinishedConsumer : IConsumer<DeliveryFinishedEvent>
    {
        private readonly IOrderHistoryService _service;

        public DeliveryFinishedConsumer(IOrderHistoryService service)
        {
            _service = service;
        }

        public Task Consume(ConsumeContext<DeliveryFinishedEvent> context)
        {
            _service.HandleOrderCompletedEvent(context.Message.OrderId);
            return Task.CompletedTask;
        }
    }
}