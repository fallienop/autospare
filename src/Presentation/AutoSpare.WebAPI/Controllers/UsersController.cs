using AutoSpare.Application.CQRSFeatures.Commands.User.CreateUser;
using AutoSpare.Application.CQRSFeatures.Commands.User.GoogleLogin;
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
        public async Task<IActionResult> GetAllUsers([FromQuery]GetAllUsersQueryRequest request)
            {
            var users = await _mediator.Send(request);    
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
            try
            {
                var resp = await _mediator.Send(request);
                if (resp.Token != null)
                {
                    return Ok(resp.Token);
                }
                else
                {
                    // Handle the case when the response token is null
                    return BadRequest("Failed to sign up. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error occurred during sign up: {ex.Message}");

                // Return a meaningful error response to the client
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during sign up. Please try again later.");
            }
        }


        [HttpPost("/[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

        [HttpPost("/google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            var resp= await _mediator.Send(request);
            return Ok(resp);
        }
    }
}
