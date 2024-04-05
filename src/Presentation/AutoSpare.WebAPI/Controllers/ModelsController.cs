using AutoSpare.Application.CQRSFeatures.Commands.Models.AddModeloMake;
using AutoSpare.Application.CQRSFeatures.Commands.Models.DeleteModel;
using AutoSpare.Application.CQRSFeatures.Commands.Models.UpdateModel;
using AutoSpare.Application.CQRSFeatures.Queries.Models.GetModelById;
using AutoSpare.Application.CQRSFeatures.Queries.Models.GetModelsOfMake;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : Controller
    {
        private readonly IMediator _mediator;

        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddModelToMake(AddModeloMakeCommandRequest request)
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



        [HttpGet("getmodels/{id}")]
        public async Task<IActionResult> GetModelsOfMake([FromRoute] ModelOMakeQueryRequest request)
        {
            var models = await _mediator.Send(request);
            return Ok(models);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetModelById([FromRoute] GetModelByIdQueryRequest request)
        {
            var model=await _mediator.Send(request);
            if (model==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(model);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelById([FromRoute] DeleteModelCommandRequest request)
        {
            var resp= await _mediator.Send(request);
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
        public async Task<IActionResult> UpdateModel(UpdateModelCommandRequest request)
        {
            var resp=await _mediator.Send(request);
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
