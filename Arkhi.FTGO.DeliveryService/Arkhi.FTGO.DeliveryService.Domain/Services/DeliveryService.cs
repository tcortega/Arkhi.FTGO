using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Domain.Entities;
using Arkhi.FTGO.DeliveryService.Domain.Entities.Enums;
using Arkhi.FTGO.DeliveryService.Domain.Exceptions;
using Arkhi.FTGO.DeliveryService.Domain.Repositories;
using Arkhi.FTGO.DeliveryService.Domain.Responses;
using Arkhi.FTGO.DeliveryService.Domain.Services.Interfaces;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.Libs.Common.Enums;
using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.DeliveryService.Domain.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly HttpClient _httpClient;
        private readonly IKitchenRepository _repository;

        public DeliveryService(IKitchenRepository repository, HttpClient httpClient)
        {
            _repository = repository;
            _httpClient = httpClient;
        }

        public DeliveryOrder Validate(int id)
        {
            var order = _repository.Find(id);

            if (order is null) throw new DeliveryOrderNotFoundException();

            return order;
        }

        public DeliveryOrder StartDelivery(int id)
        {
            var order = Validate(id);
            ValidateUpdatingOrder(order, DeliveryOrderStatus.Pending);

            order.Status = DeliveryOrderStatus.Delivering;
            _repository.Update(order);

            return order;
        }

        public DeliveryOrder FinishDelivery(int id)
        {
            var order = Validate(id);
            ValidateUpdatingOrder(order, DeliveryOrderStatus.Delivering);

            order.Status = DeliveryOrderStatus.Delivered;
            _repository.Update(order);

            return order;
        }

        public async Task HandleDelivery(KitchenFinishedEvent msg)
        {
            var customer = await _httpClient.GetFromJsonAsync<CustomerResponse>(msg.CustomerId.ToString());

            if (customer is null) throw new BusinessLogicException("Error retrieving customer data");

            var entity = CreateDeliveryOrderFromMessage(msg, customer);

            _repository.Add(entity);
            _repository.Commit();
        }

        private static DeliveryOrder CreateDeliveryOrderFromMessage(KitchenFinishedEvent msg, CustomerResponse customer)
        {
            return new()
            {
                OrderId = msg.OrderId, CustomerId = msg.CustomerId, CustomerName = customer.Name, DeliveryAddress = customer.Address,
                Status = DeliveryOrderStatus.Pending
            };
        }

        private static void ValidateUpdatingOrder(DeliveryOrder order, DeliveryOrderStatus allowedStatus)
        {
            if (order.Status == allowedStatus) return;

            throw new DeliveryOrderUpdateException(order.Status.GetDescription(true));
        }
    }
}