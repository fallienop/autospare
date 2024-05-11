using AutoSpare.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.User.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IGoogleLogin _googleLogin;
        

        public GoogleLoginCommandHandler(IGoogleLogin googleLogin)
        {
            _googleLogin = googleLogin;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
           var token = await _googleLogin.TokenViaGoogleAsync(request.IdToken, request.Provider);
            return new()
            {
                Token = token
            };
        }
    }
}
