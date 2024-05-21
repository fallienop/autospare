using AutoSpare.Application.CQRSFeatures.Commands.Categories.AddNewCategory;
using AutoSpare.Application.CQRSFeatures.Commands.Categories.DeleteCategoryById;
using AutoSpare.Application.CQRSFeatures.Commands.Categories.UpdateCategory;
using AutoSpare.Application.CQRSFeatures.Queries.Categories.GetCategoryById;
using AutoSpare.Application.CQRSFeatures.Queries.Categories.GetMainCategories;
using AutoSpare.Application.CQRSFeatures.Queries.Categories.GetSubCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetMainCategories()
        {
            var categories = _mediator.Send(new GetMainCategoriesQueryRequest());
            var res = categories.Result.Categories;
            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult GetSubCategories([FromRoute]GetSubCategoriesQueryRequest request) {
            var categories = _mediator.Send(request);
            return Ok(categories.Result.Categories);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdQueryRequest request)
        {
            var category=await _mediator.Send(request);
            return Ok(category.Category);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<IActionResult> AddNewCategory(AddNewCategoryCommandRequest request)
        {
            var resp=await _mediator.Send(request);
            if(resp.Success)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            return StatusCode((int)HttpStatusCode.BadRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> DeleteCategoryById([FromRoute]DeleteCategoryByIdCommandRequest request)
        {
            var resp= await _mediator.Send(request);
            if(resp.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);

            }
            return StatusCode((int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            var resp=await _mediator.Send(request);
            if (resp.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);

            }
            return StatusCode((int)HttpStatusCode.BadRequest);
        }


    }
}
