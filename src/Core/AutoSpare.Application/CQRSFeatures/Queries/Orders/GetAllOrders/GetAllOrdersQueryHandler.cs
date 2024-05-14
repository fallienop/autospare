using AutoSpare.Application.Repositories.OrderRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Orders.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
    {
        private readonly IOrderReadRepository _repository;
        
        public GetAllOrdersQueryHandler(IOrderReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {

            var orders = _repository.GetAll(false);
            var resp= new GetAllOrdersQueryResponse()
            {
                Orders=orders
            };
            return Task.FromResult(resp);
        }
    }
}
