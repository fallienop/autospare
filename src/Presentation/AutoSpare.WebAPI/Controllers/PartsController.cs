using AutoSpare.Application.CQRSFeatures.Commands.Parts.AddPart;
using AutoSpare.Application.CQRSFeatures.Queries.Parts.GetAllParts;
using AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsByModel;
using MediatR;
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

        [HttpGet("{id}")]
        public IActionResult GetPartsOfModel(GetPartsByModelQueryRequest request) { 
        var resp=_mediator.Send(request);
            return Ok(resp);
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(AddPartCommandRequest request)
        {
            var resp =await _mediator.Send(request);

            if (resp.Success)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

    }
}
