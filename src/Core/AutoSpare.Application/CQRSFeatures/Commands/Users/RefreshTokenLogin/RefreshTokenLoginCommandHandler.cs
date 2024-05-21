using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.Abstractions.TokenAbstraction;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public RefreshTokenLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user=await _userManager.Users.FirstOrDefaultAsync(x=>x.RefreshToken==request.RefreshToken);
            if(user!=null&& user?.RefreshTokenExpiration > DateTime.UtcNow)
            {
                var token = await _tokenHandler.CreateAccessToken(user);
              await  _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration);

                return new()
                {
                    Token = token
                };
            }
            throw new Exception("RefreshTokenLogin error");
        }
    }
}
