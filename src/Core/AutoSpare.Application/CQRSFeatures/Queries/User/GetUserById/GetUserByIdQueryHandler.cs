using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.Application.CQRSFeatures.Queries.User.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            return new()
            {
                User = user
            };
        }
    }
}
