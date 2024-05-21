using AutoSpare.Application.CQRSFeatures.Commands.Brands.AddBrand;
using AutoSpare.Application.CQRSFeatures.Commands.Brands.DeleteBrand;
using AutoSpare.Application.CQRSFeatures.Commands.Brands.UpdateBrand;
using AutoSpare.Application.CQRSFeatures.Queries.Brands.GetBrandById;
using AutoSpare.Application.CQRSFeatures.Queries.Brands.GetBrands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult GetBrands()
        {
            var resp = _mediator.Send(new GetBrandsQueryRequest());
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById([FromRoute] GetBrandByIdQueryRequest request)
        {
            var brand = await _mediator.Send(request);
            return Ok(brand.Brand);
        }

        [HttpPost]
        [Authorize(Roles = "superadmin,admin")]
        public async Task<IActionResult> AddBrand(AddBrandCommandRequest request)
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "superadmin,admin")]
        public async Task<IActionResult> DeleteBrand([FromRoute]DeleteBrandCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)(HttpStatusCode.OK));
            }
            return StatusCode((int)(HttpStatusCode.NotModified));
        }

        [HttpPut]
        [Authorize(Roles = "superadmin,admin")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);

            }
            return StatusCode((int)HttpStatusCode.BadRequest);
        }
    }
}
