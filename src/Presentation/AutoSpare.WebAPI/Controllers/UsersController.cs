using AutoSpare.Application.CQRSFeatures.Commands.User.CreateUser;
using AutoSpare.Application.CQRSFeatures.Commands.User.LoginUser;
using AutoSpare.Application.CQRSFeatures.Queries.User.GetAllUsers;
using AutoSpare.Application.CQRSFeatures.Queries.User.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQueryRequest());    
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] GetUserByIdQueryRequest request)
        {
            var user = await _mediator.Send(request);
            return Ok(user);
        }

        [HttpPost("/[action]")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserCommandRequest request)
        {
            var resp=await _mediator.Send(request);
            if(resp.Success)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }


        [HttpPost("/[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }
    }
}
