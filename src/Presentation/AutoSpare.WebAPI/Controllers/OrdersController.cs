using AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder;
using AutoSpare.Application.CQRSFeatures.Queries.Orders.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("getall")]
        public IActionResult GetAllOrders()
        {
            var resp=_mediator.Send(new GetAllOrdersQueryRequest());
            return Ok(resp);
        }
    }
}
