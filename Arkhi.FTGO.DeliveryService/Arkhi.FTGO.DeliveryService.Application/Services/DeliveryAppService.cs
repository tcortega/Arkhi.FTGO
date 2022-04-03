using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Application.Dtos.Responses;
using Arkhi.FTGO.DeliveryService.Application.Services.Interfaces;
using Arkhi.FTGO.DeliveryService.Domain.Events;
using Arkhi.FTGO.DeliveryService.Domain.Repositories;
using Arkhi.FTGO.DeliveryService.Domain.Services.Interfaces;
using Arkhi.FTGO.Libs.Infra.Transactions;
using AutoMapper;
using MassTransit;

namespace Arkhi.FTGO.DeliveryService.Application.Services
{
    public class DeliveryAppService : IDeliveryAppService
    {
        private readonly IDeliveryService _deliveryService;
        private readonly IKitchenRepository _kitchenRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publisher;
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryAppService(IDeliveryService deliveryService, IKitchenRepository kitchenRepository, IUnitOfWork unitOfWork, IMapper mapper,
            IPublishEndpoint publisher)
        {
            _deliveryService = deliveryService;
            _kitchenRepository = kitchenRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publisher = publisher;
        }

        public DeliveryOrderResponse Get(int id)
        {
            var kitchenOrder = _deliveryService.Validate(id);

            return _mapper.Map<DeliveryOrderResponse>(kitchenOrder);
        }

        public IEnumerable<DeliveryOrderResponse> Get()
        {
            var orders = _kitchenRepository.Query().ToList();
            return _mapper.Map<IEnumerable<DeliveryOrderResponse>>(orders);
        }

        public async Task StartDelivery(int id)
        {
            var order = _deliveryService.StartDelivery(id);
            _unitOfWork.Commit();

            await _publisher.Publish<DeliveryStartedEvent>(new
            {
                order.OrderId,
                order.DeliveryAddress
            });
        }

        public async Task FinishDelivery(int id)
        {
            var order = _deliveryService.FinishDelivery(id);
            _unitOfWork.Commit();

            await _publisher.Publish<DeliveryFinishedEvent>(new
            {
                order.OrderId
            });
        }
    }
}