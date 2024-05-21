using AutoSpare.Application.CQRSFeatures.Commands.Plates.AddPlate;
using AutoSpare.Application.CQRSFeatures.Commands.Plates.DeletePlate;
using AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlates;
using AutoSpare.Application.CQRSFeatures.Queries.Plates.GetPlateWithFilter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetPlates()
        {
            var resp = _mediator.Send(new GetPlatesQueryRequest());
            return Ok(resp);
        }

        [HttpPost]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> AddPlate(AddPlateCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("filter")]
        public IActionResult GetPlates([FromQuery] GetPlateWithFilterQueryRequest request)
        {
            var resp = _mediator.Send(request);
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> DeletePlate([FromQuery] DeletePlateCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return StatusCode(resp.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest);
        }
    }
}
