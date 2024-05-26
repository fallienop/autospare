using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Orders.GetOrdersOfCompany
{
    public class GetOrdersOfCompanyQueryHandler : IRequestHandler<GetOrdersOfCompanyQueryRequest, GetOrdersOfCompanyQueryResponse>
    {
        private readonly IOrderReadRepository _repository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public GetOrdersOfCompanyQueryHandler(IOrderReadRepository repository, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<GetOrdersOfCompanyQueryResponse> Handle(GetOrdersOfCompanyQueryRequest request, CancellationToken cancellationToken)
        {
            var username = _contextAccessor.HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            var user = await _userManager.FindByNameAsync(username);

            var ordersOfCompany = await _repository.GetWhere(o => o.OrderPart.Any(op => op.Part.CompanyId == user.CompanyId))
                .Include(o => o.OrderPart)
                    .ThenInclude(op => op.Part)
                .ToListAsync(cancellationToken);

            var result = ordersOfCompany.SelectMany(o => o.OrderPart.Where(op => op.Part.CompanyId == user.CompanyId)
                .Select(op => new OrderOfCompanyReturnDTO
                {
                    OrderId = o.Id,
                    //AppUserId = o.AppUserId,
                    NameSurname =user.NameSurname,
                    PartId = op.Part.Id,
                    PartName =op.Part.Name,
                    PartCode=op.Part.Code,
                    //CompanyId = op.Part.CompanyId,
                    Count = op.Count,
                    Address=o.Address,
                    Status=op.Status
                }))
                .ToList();

            return new GetOrdersOfCompanyQueryResponse
            {
                Orders = result
            };
        }


    }
}
