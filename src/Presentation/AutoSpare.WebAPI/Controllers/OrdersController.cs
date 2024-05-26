using AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder;
using AutoSpare.Application.CQRSFeatures.Commands.Orders.ChangeOrderStatus;
using AutoSpare.Application.CQRSFeatures.Queries.Orders.GetAllOrders;
using AutoSpare.Application.CQRSFeatures.Queries.Orders.GetOrdersOfCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderCommandRequest request)
        {     
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

        [HttpGet("getall")]

        public IActionResult GetAllOrders()
        {
            var resp=_mediator.Send(new GetAllOrdersQueryRequest());
            return Ok(resp);
        }

        [HttpGet("ordersofcompany")]
        [Authorize(Roles="admin")]
         public async Task<IActionResult> GetOrdersOfCompany()
        {
            var resp = await _mediator.Send(new GetOrdersOfCompanyQueryRequest());
            return Ok(resp);
        }

        [HttpPost("changeorderstatus")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusCommandRequest request)
        {
            var resp=await _mediator.Send(request); 
            return Ok(resp);
        }
    }
}
