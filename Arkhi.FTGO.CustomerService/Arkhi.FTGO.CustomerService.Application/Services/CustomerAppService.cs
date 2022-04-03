using Arkhi.FTGO.CustomerService.Application.Dtos.Requests;
using Arkhi.FTGO.CustomerService.Application.Dtos.Responses;
using Arkhi.FTGO.CustomerService.Application.Services.Interfaces;
using Arkhi.FTGO.CustomerService.Domain.Entities;
using Arkhi.FTGO.CustomerService.Domain.Repositories;
using Arkhi.FTGO.CustomerService.Domain.Services.Interfaces;
using Arkhi.FTGO.Libs.Infra.Transactions;
using AutoMapper;

namespace Arkhi.FTGO.CustomerService.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAppService(ICustomerService customerService, ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CustomerResponse GetById(int id)
        {
            var customer = _customerService.Validate(id);

            return _mapper.Map<CustomerResponse>(customer);
        }

        public CustomerResponse Add(CustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);

            _customerRepository.Add(customer);
            _unitOfWork.Commit();

            return _mapper.Map<CustomerResponse>(customer);
        }

        public CustomerResponse Update(int id, CustomerRequest request)
        {
            var customer = _customerService.Validate(id);

            customer.Name = request.Name;
            customer.Address = request.Address;

            _customerRepository.Update(customer);
            _unitOfWork.Commit();

            return _mapper.Map<CustomerResponse>(customer);
        }

        public void Remove(int id)
        {
            _customerService.Remove(id);
            _unitOfWork.Commit();
        }

        public CustomerResponse AddBalance(AddBalanceRequest request)
        {
            var customer = _customerService.Validate(request.Id);

            _customerService.AddBalance(customer, request.Balance);
            _unitOfWork.Commit();

            return _mapper.Map<CustomerResponse>(customer);
        }

        public void ChargeCustomer(ChargeCustomerRequest request)
        {
            _customerService.ChargeCustomer(request.CustomerId, request.OrderPrice);
            _unitOfWork.Commit();
        }
    }
}