using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Arkhi.FTGO.OrderService.Domain.Commands;
using Arkhi.FTGO.OrderService.Domain.Entities;
using Arkhi.FTGO.OrderService.Domain.Exceptions;
using Arkhi.FTGO.OrderService.Domain.Repositories;
using Arkhi.FTGO.OrderService.Domain.Requests;
using Arkhi.FTGO.OrderService.Domain.Services.Interfaces;

namespace Arkhi.FTGO.OrderService.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository, IOrderItemRepository orderItemRepository, HttpClient httpClient)
        {
            _repository = repository;
            _orderItemRepository = orderItemRepository;
            _httpClient = httpClient;
        }

        public Order Validate(int id)
        {
            var order = _repository.Find(id);

            if (order is null) throw new OrderNotFoundException();

            return order;
        }

        public async Task<Order> Add(CreateNewOrderCommand command)
        {
            var orderTotal = command.Items.Sum(x => x.Price * x.Quantity);

            var orderItems = command.Items.Select(CreateOrderItemFromCommand).ToList();
            var order = CreateOrderFromCommand(command, orderItems, orderTotal);
            _repository.Add(order);
            _orderItemRepository.Add(orderItems);

            await ChargeCustomer(command.CustomerId, orderTotal);

            return order;
        }

        public async Task HandleOrderCancelledEvent(int orderId)
        {
            var order = Validate(orderId);
            await RefundCustomer(order.CustomerId, order.Total);
        }

        private async Task RefundCustomer(int customerId, decimal orderTotal)
        {
            using var response = await _httpClient.PutAsJsonAsync("balances", RefundCustomerRequest.Create(customerId, orderTotal));

            if (!response.IsSuccessStatusCode) throw new ErrorRefundingCustomer();
        }

        private async Task ChargeCustomer(int customerId, decimal orderTotal)
        {
            using var response = await _httpClient.PutAsJsonAsync("charges", ChargeCustomerRequest.Create(customerId, orderTotal));

            if (!response.IsSuccessStatusCode) throw new ErrorChargingCustomer();
        }

        private static Order CreateOrderFromCommand(CreateNewOrderCommand command, ICollection<OrderItem> orderItems, decimal orderTotal)
        {
            return new Order
            {
                CustomerId = command.CustomerId,
                Items = orderItems,
                Total = orderTotal
            };
        }

        private static OrderItem CreateOrderItemFromCommand(CreateNewOrderItemCommand command)
        {
            return new() {Name = command.Name, Price = command.Price, Quantity = command.Quantity};
        }
    }
}