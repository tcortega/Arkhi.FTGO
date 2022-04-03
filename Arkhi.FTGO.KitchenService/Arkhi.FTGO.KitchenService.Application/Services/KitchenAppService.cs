using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Application.Dtos.Responses;
using Arkhi.FTGO.KitchenService.Application.Services.Interfaces;
using Arkhi.FTGO.KitchenService.Domain.Events;
using Arkhi.FTGO.KitchenService.Domain.Repositories;
using Arkhi.FTGO.KitchenService.Domain.Services.Interfaces;
using Arkhi.FTGO.Libs.Infra.Transactions;
using AutoMapper;
using MassTransit;

namespace Arkhi.FTGO.KitchenService.Application.Services
{
    public class KitchenAppService : IKitchenAppService
    {
        private readonly IKitchenRepository _kitchenRepository;
        private readonly IKitchenService _kitchenService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publisher;
        private readonly IUnitOfWork _unitOfWork;

        public KitchenAppService(IKitchenService kitchenService, IKitchenRepository kitchenRepository, IUnitOfWork unitOfWork, IMapper mapper,
            IPublishEndpoint publisher)
        {
            _kitchenService = kitchenService;
            _kitchenRepository = kitchenRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _publisher = publisher;
        }

        public KitchenOrderResponse Get(int id)
        {
            var kitchenOrder = _kitchenService.Validate(id);

            return _mapper.Map<KitchenOrderResponse>(kitchenOrder);
        }

        public IEnumerable<KitchenOrderResponse> Get()
        {
            var orders = _kitchenRepository.Query().ToList();
            return _mapper.Map<IEnumerable<KitchenOrderResponse>>(orders);
        }

        public async Task FinishOrder(int id)
        {
            var order = _kitchenService.FinishOrder(id);
            _unitOfWork.Commit();

            await _publisher.Publish<KitchenFinishedEvent>(new
            {
                order.OrderId,
                order.CustomerId
            });
        }

        public async Task CancelOrder(int id)
        {
            var order = _kitchenService.CancelOrder(id);
            _unitOfWork.Commit();

            await _publisher.Publish<KitchenCancelledEvent>(new
            {
                order.OrderId
            });
        }
    }
}