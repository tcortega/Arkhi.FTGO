using Arkhi.FTGO.CustomerService.Domain.Entities;
using Arkhi.FTGO.CustomerService.Domain.Repositories;
using Arkhi.FTGO.CustomerService.Infra.Data;
using Arkhi.FTGO.Libs.Infra;

namespace Arkhi.FTGO.CustomerService.Infra.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}