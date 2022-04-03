using Arkhi.FTGO.CustomerService.Domain.Entities;
using Arkhi.FTGO.Libs.Domain.Repositories;

namespace Arkhi.FTGO.CustomerService.Domain.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
    }
}