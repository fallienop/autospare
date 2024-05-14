using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.Abstractions.TokenAbstraction;
using AutoSpare.Application.DTOs;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            }
            if (user == null)
            {
                throw new Exception("Yanlış istifadəçi adı və ya email");
            }
            var resp = await _userManager.CheckPasswordAsync(user, request.Password);

            if (resp)
            {
                Token token = _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration);
                //await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return new LoginUserSuccessCommandResponse() { Token = token };
            }
            else
            {
                return new LoginUserErrorCommandResponse()
                {
                    Message = "Yanlış istifadəçi adı və ya şifrə"
                };
            }
        }
    }
}
