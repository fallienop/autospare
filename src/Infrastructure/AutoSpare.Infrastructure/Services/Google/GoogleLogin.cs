using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Application.Abstractions.TokenAbstraction;
using AutoSpare.Application.DTOs;
using AutoSpare.Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.Infrastructure.Services.Google
{
    public class GoogleLogin : IGoogleLogin
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public GoogleLogin(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<Token> TokenViaGoogleAsync(string idToken, string provider)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "1005950461350-bqcbh376cthqii5cuc8mmijoeook6eov.apps.googleusercontent.com" }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo(provider, payload.Subject, provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result=user != null;
            if (!result)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name
                    };
                }
            }
            if (result)
                await _userManager.AddLoginAsync(user, info);
            else
                throw new Exception("Invalid external authentication");
            Token token = await _tokenHandler.CreateAccessToken(user);
            await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration);

            return token;
        }
    }
}
