using AutoSpare.Application.Repositories.TireRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Tires.GetTires
{
    public class GetTiresQueryHandler : IRequestHandler<GetTiresQueryRequest, GetTiresQueryResponse>
    {
        private readonly ITireReadRepository _repository;

        public GetTiresQueryHandler(ITireReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetTiresQueryResponse> Handle(GetTiresQueryRequest request, CancellationToken cancellationToken)
        {
           var tires = _repository.GetAll(false);
            var resp = new GetTiresQueryResponse()
            {
                Tires = tires
            };
            return Task.FromResult(resp);
        }
    }
}
