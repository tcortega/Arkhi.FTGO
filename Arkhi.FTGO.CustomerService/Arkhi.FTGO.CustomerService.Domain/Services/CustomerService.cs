using Arkhi.FTGO.CustomerService.Domain.Entities;
using Arkhi.FTGO.CustomerService.Domain.Exceptions;
using Arkhi.FTGO.CustomerService.Domain.Repositories;
using Arkhi.FTGO.CustomerService.Domain.Services.Interfaces;
using Arkhi.FTGO.Libs.Domain.Exceptions;

namespace Arkhi.FTGO.CustomerService.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer Validate(int id)
        {
            var customer = _repository.Find(id);

            if (customer is null || !customer.IsActive) throw new CustomerNotFoundException();

            return customer;
        }

        public void Remove(int id)
        {
            var customer = Validate(id);

            if (customer.Balance > 0M) throw new BusinessLogicException("It is not possible to delete a customer that has remaining balance");

            customer.IsActive = false;
            _repository.Update(customer);
        }

        public void AddBalance(Customer customer, decimal balance)
        {
            customer.Balance += balance;

            _repository.Update(customer);
        }

        public void ChargeCustomer(int customerId, decimal orderTotal)
        {
            var customer = Validate(customerId);

            if (customer.Balance < orderTotal) throw new BusinessLogicException("The customer does not have enough balance to pay for this order.");

            customer.Balance -= orderTotal;
            _repository.Update(customer);
        }
    }
}