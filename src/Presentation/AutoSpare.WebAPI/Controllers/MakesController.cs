using AutoSpare.Application.CQRSFeatures.Commands.Makes.AddNewMake;
using AutoSpare.Application.CQRSFeatures.Commands.Makes.DeleteMake;
using AutoSpare.Application.CQRSFeatures.Commands.Makes.UpdateMake;
using AutoSpare.Application.CQRSFeatures.Queries.Makes.GetAllMakes;
using AutoSpare.Application.CQRSFeatures.Queries.Makes.GetMakeById;
using AutoSpare.Application.Repositories.ProductRepos.MakeRepo;
using AutoSpare.Domain.Entities.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Text;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    { 
        private readonly IMediator _mediator;

        public MakesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult GetAllMakes()
        {
            var allMakes = _mediator.Send(new GetAllMakesQueryRequest());
            return Ok(allMakes.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMakeById([FromRoute]GetMakeByIdQueryRequest request)
        {
            var make = await _mediator.Send(request);
            if (make == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(make);
            }
        }

        [HttpPost("/add")]
        public async Task<IActionResult> AddMakes(AddMakeCommandRequest request)
        {
            var resp =await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)(HttpStatusCode.Created));
            }
            return StatusCode((int)(HttpStatusCode.NotAcceptable));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake([FromRoute]DeleteMakeCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)(HttpStatusCode.OK));
            }
            return StatusCode((int)(HttpStatusCode.NotModified));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMake([FromBody] UpdateMakeCommandRequest request)
        {
            var resp=await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)(HttpStatusCode.OK));
            }
            return StatusCode((int)(HttpStatusCode.NoContent));

        }


    }
}
