using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.User.GetRoleOfUser
{
    public class GetRoleOfUserQueryHandler : IRequestHandler<GetRoleOfUserQueryRequest, GetRoleOfUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetRoleOfUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetRoleOfUserQueryResponse> Handle(GetRoleOfUserQueryRequest request, CancellationToken cancellationToken)
        {
           var user=await _userManager.FindByIdAsync(request.Id);
           var role=await _userManager.GetRolesAsync(user);
            return new()
            {
                Role = role,
                CompanyId=user.CompanyId
            };
        }
    }
}
