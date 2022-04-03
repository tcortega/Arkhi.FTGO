using Arkhi.FTGO.CustomerService.Application.Dtos.Requests;
using Arkhi.FTGO.CustomerService.Application.Dtos.Responses;

namespace Arkhi.FTGO.CustomerService.Application.Services.Interfaces
{
    public interface ICustomerAppService
    {
        CustomerResponse GetById(int id);
        CustomerResponse Add(CustomerRequest request);
        CustomerResponse Update(int id, CustomerRequest request);
        void Remove(int id);
        CustomerResponse AddBalance(AddBalanceRequest request);
        void ChargeCustomer(ChargeCustomerRequest request);
    }
}