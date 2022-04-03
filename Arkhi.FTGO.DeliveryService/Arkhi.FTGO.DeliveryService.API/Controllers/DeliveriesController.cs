using System.Collections.Generic;
using System.Threading.Tasks;
using Arkhi.FTGO.DeliveryService.Application.Dtos.Responses;
using Arkhi.FTGO.DeliveryService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arkhi.FTGO.DeliveryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveryAppService _deliveryAppService;

        public DeliveriesController(IDeliveryAppService deliveryAppService)
        {
            _deliveryAppService = deliveryAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeliveryOrderResponse>> Get()
        {
            return Ok(_deliveryAppService.Get());
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<DeliveryOrderResponse>> Get(int id)
        {
            return Ok(_deliveryAppService.Get(id));
        }

        [HttpPut("pickup/{id:int}")]
        public async Task<ActionResult<DeliveryOrderResponse>> StartDelivery([FromRoute] int id)
        {
            await _deliveryAppService.StartDelivery(id);
            return Ok();
        }

        [HttpPut("deliver/{id:int}")]
        public async Task<ActionResult<DeliveryOrderResponse>> FinishDelivery([FromRoute] int id)
        {
            await _deliveryAppService.FinishDelivery(id);
            return Ok();
        }
    }
}