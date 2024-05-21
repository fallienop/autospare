using AutoSpare.Application.CQRSFeatures.Commands.Companies.AddCompany;
using AutoSpare.Application.CQRSFeatures.Commands.Companies.DeleteCompany;
using AutoSpare.Application.CQRSFeatures.Commands.Companies.UpdateCompany;
using AutoSpare.Application.CQRSFeatures.Queries.Companies.GetCompanies;
using AutoSpare.Application.CQRSFeatures.Queries.Companies.GetCompanyById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetCompany()
        {
            var resp = _mediator.Send(new GetCompanyQueryRequest());
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById([FromRoute] GetCompanyByIdQueryRequest request)
        {
            var company = await _mediator.Send(request);
            return Ok(company.Company);
        }


        [HttpPost]
        [Authorize(Roles = "superadmin,admin")]
        public async Task<IActionResult> AddCompany(AddCompanyCommandRequest request)
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "superadmin,admin")]
        public async Task<IActionResult> DeleteCompany([FromRoute] DeleteCompanyCommandRequest request)
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
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyCommandRequest request)
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
