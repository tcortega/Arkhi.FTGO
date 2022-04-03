using System.Threading.Tasks;
using Arkhi.FTGO.OrderService.Application.Dtos.Requests;
using Arkhi.FTGO.OrderService.Application.Dtos.Responses;
using Arkhi.FTGO.OrderService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arkhi.FTGO.OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrdersController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderResponse> Get(int id)
        {
            return Ok(_orderAppService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Add(OrderRequest request)
        {
            return Ok(await _orderAppService.Add(request));
        }
    }
}