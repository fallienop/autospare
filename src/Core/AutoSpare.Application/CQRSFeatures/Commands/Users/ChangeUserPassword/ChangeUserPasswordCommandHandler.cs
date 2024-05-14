using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommandRequest, ChangeUserPasswordCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public ChangeUserPasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ChangeUserPasswordCommandResponse> Handle(ChangeUserPasswordCommandRequest request, CancellationToken cancellationToken)
        {
          var user =await _userManager.FindByNameAsync(request.UserName);
            var resp=await _userManager.ChangePasswordAsync(user,request.OldPassword,request.NewPassword);
            return new() {
            Success=resp.Succeeded
            };
        }
    }
}
