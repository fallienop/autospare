using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Domain.Entities;
using AutoSpare.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public AddOrderCommandHandler(IOrderWriteRepository repository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                AppUser? user=await _userManager.FindByNameAsync(userName);

                var OrderParts = new List<OrderPart>();

                foreach (var pnc in request.PartsandCounts)
                {

                    OrderParts.Add(new() { Count = pnc.Count, PartId = Guid.Parse(pnc.ProductId) });

                }
                await _repository.AddAsync(new()
                {
                    OrderPart = OrderParts,
                    Address = request.Address,
                    AppUserId=user.Id
                });

                var resp = await _repository.SaveAsync();

                return new() { Success = resp > 0 };
            }
            return new() { Success = false};
        }
    }
}
