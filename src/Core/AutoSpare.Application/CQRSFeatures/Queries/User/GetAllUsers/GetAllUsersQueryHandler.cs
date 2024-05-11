using AutoSpare.Application.Abstractions.Services;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.User.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
    {
        private readonly IUserService _userService;

        public GetAllUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

     

        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
           var users= await _userService.GetAllUsers(request.Page,request.Size);
            return new()
            {
                Users = users
            };
        }
    }
}
