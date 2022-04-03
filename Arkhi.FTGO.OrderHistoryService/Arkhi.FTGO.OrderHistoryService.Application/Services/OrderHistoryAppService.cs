using System.Collections.Generic;
using System.Linq;
using Arkhi.FTGO.Libs.Infra.Transactions;
using Arkhi.FTGO.OrderHistoryService.Application.Dtos.Responses;
using Arkhi.FTGO.OrderHistoryService.Application.Services.Interfaces;
using Arkhi.FTGO.OrderHistoryService.Domain.Exceptions;
using Arkhi.FTGO.OrderHistoryService.Domain.Repositories;
using AutoMapper;

namespace Arkhi.FTGO.OrderHistoryService.Application.Services
{
    public class OrderHistoryAppService : IOrderHistoryAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderHistoryAppService(IOrderHistoryRepository orderHistoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public OrderHistoryResponse GetById(int id)
        {
            var orderHistory = _orderHistoryRepository.Find(id);

            if (orderHistory is null) throw new OrderHistoryNotFoundException();

            return _mapper.Map<OrderHistoryResponse>(orderHistory);
        }

        public OrderHistoryResponse GetByOrderId(int orderId)
        {
            var orderHistory = _orderHistoryRepository.Find(x => x.OrderId == orderId);

            if (orderHistory is null) throw new OrderHistoryNotFoundException();

            return _mapper.Map<OrderHistoryResponse>(orderHistory);
        }

        public IEnumerable<OrderHistoryResponse> GetByCustomerId(int customerId)
        {
            var orders = _orderHistoryRepository.Query()
                .Where(x => x.CustomerId == customerId)
                .ToList();

            return _mapper.Map<IEnumerable<OrderHistoryResponse>>(orders);
        }
    }
}