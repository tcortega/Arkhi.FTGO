using System.Collections.Generic;
using Arkhi.FTGO.OrderHistoryService.Application.Dtos.Responses;
using Arkhi.FTGO.OrderHistoryService.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arkhi.FTGO.OrderHistoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersHistoryController : ControllerBase
    {
        private readonly IOrderHistoryAppService _orderHistoryAppService;

        public OrdersHistoryController(IOrderHistoryAppService orderHistoryAppService)
        {
            _orderHistoryAppService = orderHistoryAppService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<OrderHistoryResponse> Get(int id)
        {
            return Ok(_orderHistoryAppService.GetById(id));
        }

        [HttpGet("orders/{orderId:int}")]
        public ActionResult<OrderHistoryResponse> GetByOrderId(int orderId)
        {
            return Ok(_orderHistoryAppService.GetByOrderId(orderId));
        }

        [HttpGet("customers/{customerId:int}")]
        public ActionResult<IEnumerable<OrderHistoryResponse>> GetByCustomerId(int customerId)
        {
            return Ok(_orderHistoryAppService.GetByCustomerId(customerId));
        }
    }
}