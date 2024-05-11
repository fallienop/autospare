using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.Abstractions.TokenAbstraction;
using AutoSpare.Application.CQRSFeatures.Commands.User.LoginUser;
using AutoSpare.Application.DTOs;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.Application.CQRSFeatures.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            var result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            }, request.Password);
            if (result.Succeeded)
            {
                var newUser = await _userManager.FindByEmailAsync(request.Email);
                if (newUser != null)
                {
                    // User created successfully, perform additional actions if needed
                    Token token = _tokenHandler.CreateAccessToken();
                    await _userService.UpdateRefreshToken(token.RefreshToken, newUser, token.Expiration);
                    //await _userService.UpdateRefreshTokenAsync(token.RefreshToken, newUser, token.Expiration, 15);
                    return new CreateUserCommandResponse() { Token = token };
                }
                throw new Exception("error while signup");
            }
            else
            {
                throw new Exception("error while signup");

            }
        }
    }
}
