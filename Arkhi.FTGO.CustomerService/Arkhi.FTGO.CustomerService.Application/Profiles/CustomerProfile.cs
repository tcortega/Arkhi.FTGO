using Arkhi.FTGO.CustomerService.Application.Dtos.Requests;
using Arkhi.FTGO.CustomerService.Application.Dtos.Responses;
using Arkhi.FTGO.CustomerService.Domain.Entities;
using AutoMapper;

namespace Arkhi.FTGO.CustomerService.Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerRequest, Customer>();
        }
    }
}