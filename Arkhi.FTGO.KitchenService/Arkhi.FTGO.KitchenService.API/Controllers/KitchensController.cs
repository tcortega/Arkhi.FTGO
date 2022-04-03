using System.Collections.Generic;
using System.Threading.Tasks;
using Arkhi.FTGO.KitchenService.Application.Dtos.Responses;
using Arkhi.FTGO.KitchenService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arkhi.FTGO.KitchenService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitchensController : ControllerBase
    {
        private readonly IKitchenAppService _kitchenAppService;

        public KitchensController(IKitchenAppService kitchenAppService)
        {
            _kitchenAppService = kitchenAppService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KitchenOrderResponse>> Get()
        {
            return Ok(_kitchenAppService.Get());
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<KitchenOrderResponse>> Get(int id)
        {
            return Ok(_kitchenAppService.Get(id));
        }

        [HttpPut("finish/{id:int}")]
        public async Task<ActionResult<KitchenOrderResponse>> FinishOrder([FromRoute] int id)
        {
            await _kitchenAppService.FinishOrder(id);
            return Ok();
        }

        [HttpDelete("cancel/{id:int}")]
        public async Task<ActionResult<KitchenOrderResponse>> CancelOrder([FromRoute] int id)
        {
            await _kitchenAppService.CancelOrder(id);
            return Ok();
        }
    }
}