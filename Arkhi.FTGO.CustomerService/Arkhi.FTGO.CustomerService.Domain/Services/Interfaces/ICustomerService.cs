using Arkhi.FTGO.CustomerService.Domain.Entities;

namespace Arkhi.FTGO.CustomerService.Domain.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer Validate(int id);
        void Remove(int id);
        void AddBalance(Customer customer, decimal balance);
        void ChargeCustomer(int customerId, decimal orderTotal);
    }
}