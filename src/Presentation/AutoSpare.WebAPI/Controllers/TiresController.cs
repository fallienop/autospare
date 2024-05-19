using AutoSpare.Application.CQRSFeatures.Commands.Tires.AddTire;
using AutoSpare.Application.CQRSFeatures.Commands.Tires.DeleteTire;
using AutoSpare.Application.CQRSFeatures.Commands.Tires.UpdateTire;
using AutoSpare.Application.CQRSFeatures.Queries.Tires.GetTires;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TiresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TiresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resp = _mediator.Send(new GetTiresQueryRequest());
            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> AddTire(AddTireCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return StatusCode(resp.Success ? (int)HttpStatusCode.Created : (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTire(UpdateTireCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return StatusCode(resp.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTire(DeleteTireCommandRequest request)
        {
            var resp= await _mediator.Send(request);
            return StatusCode(resp.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest);

        }
    }
}
