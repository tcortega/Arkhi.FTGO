using Arkhi.FTGO.CustomerService.Application.Dtos.Requests;
using Arkhi.FTGO.CustomerService.Application.Dtos.Responses;
using Arkhi.FTGO.CustomerService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arkhi.FTGO.CustomerService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<CustomerResponse> Get(int id)
        {
            return Ok(_customerAppService.GetById(id));
        }

        [HttpPost]
        public ActionResult<CustomerResponse> Add(CustomerRequest request)
        {
            return Ok(_customerAppService.Add(request));
        }

        [HttpPut("{id:int}")]
        public ActionResult<CustomerResponse> Update([FromRoute] int id, [FromBody] CustomerRequest request)
        {
            return Ok(_customerAppService.Update(id, request));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Remove(int id)
        {
            _customerAppService.Remove(id);
            return Ok();
        }

        [HttpPut("balances")]
        public ActionResult<CustomerResponse> AddBalance(AddBalanceRequest request)
        {
            return Ok(_customerAppService.AddBalance(request));
        }

        [HttpPut("charges")]
        public ActionResult ChargeCustomer(ChargeCustomerRequest request)
        {
            _customerAppService.ChargeCustomer(request);
            return Ok();
        }
    }
}