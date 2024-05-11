using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Domain.Entities;
using MediatR;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _repository;
        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var OrderParts=new List<OrderPart>();

            foreach (var pnc in request.PartsandCounts)
            {
             
                OrderParts.Add(new() { Count = pnc.Count,PartId=Guid.Parse(pnc.ProductId) });
                
            }
            await _repository.AddAsync(new() { 
            OrderPart=OrderParts,
            Address=request.Address
            });

            var resp =await _repository.SaveAsync();

            return new() { Success = resp > 0 };
        }
    }
}
