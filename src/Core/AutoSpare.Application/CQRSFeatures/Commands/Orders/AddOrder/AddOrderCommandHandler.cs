using AutoSpare.Application.Repositories.OrderRepo;
using AutoSpare.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Commands.Orders.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _repository;
        public Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            _repository.AddAsync(new() { 
            
            });
            throw new NotImplementedException();
        }
    }
}
