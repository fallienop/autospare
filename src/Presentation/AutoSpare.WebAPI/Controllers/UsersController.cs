using AutoSpare.Application.CQRSFeatures.Commands.Users.AddRoleToUser;
using AutoSpare.Application.CQRSFeatures.Commands.Users.CreateUser;
using AutoSpare.Application.CQRSFeatures.Commands.Users.GoogleLogin;
using AutoSpare.Application.CQRSFeatures.Commands.Users.LoginUser;
using AutoSpare.Application.CQRSFeatures.Queries.User.GetAllUsers;
using AutoSpare.Application.CQRSFeatures.Queries.User.GetRoleOfUser;
using AutoSpare.Application.CQRSFeatures.Queries.User.GetUserById;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace AutoSpare.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest request)
        {
            var users = await _mediator.Send(request);
            return Ok(users);
        }

        [HttpPost("roleAdd")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> AddRoleToUser([FromBody] AddRoleToUserCommandRequest request)
        {
            var resp = await _mediator.Send(request);
            return StatusCode(resp.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest);

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "superadmin")]
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
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {

            var username = User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (username == null)
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByNameAsync(username);
            // Retrieve the user details from the database using the userId
            // your code to get the user from the database

            return Ok(user);
        }

        [HttpGet("getrole/{id}")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> GetRoleOfUser([FromRoute] GetRoleOfUserQueryRequest request)
        {
            var resp = await _mediator.Send(request);
            return Ok(resp);
        }

    }
}
