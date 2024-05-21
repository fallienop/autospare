using AutoSpare.Application.CQRSFeatures.Commands.Parts.AddPart;
using AutoSpare.Application.CQRSFeatures.Commands.Parts.DeletePart;
using AutoSpare.Application.CQRSFeatures.Commands.Parts.UpdatePart;
using AutoSpare.Application.CQRSFeatures.Queries.Parts.GetAllParts;
using AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPart;
using AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsByModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartsController : Controller
    {
        private readonly IMediator _mediator;

        public PartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resp = _mediator.Send(new GetAllPartsQueryRequest());
            return Ok(resp);
        }

        [HttpGet("partsofmodel/{id}")]
        public IActionResult GetPartsOfModel([FromRoute]GetPartsByModelQueryRequest request) { 
        var resp=_mediator.Send(request);
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartsById([FromRoute]GetPartQueryRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }



        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddPart([FromBody] AddPartCommandRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success

            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart([FromRoute]DeletePartCommandRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdatePart([FromBody]UpdatePartCommandRequest request)
        {
            var resp = await _mediator.Send(request);

            if (resp.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }
    }
}
