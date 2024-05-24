using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.Application.CQRSFeatures.Commands.Users.AddRoleToUser
{
    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommandRequest, AddRoleToUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public AddRoleToUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AddRoleToUserCommandResponse> Handle(AddRoleToUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
          await  _userManager.AddToRoleAsync(user, "admin");
            user.CompanyId = request.CompanyId;
           var resp =  await _userManager.UpdateAsync(user);
            return new AddRoleToUserCommandResponse()
            {
                Success = resp.Succeeded
            };
        }
    }
}
