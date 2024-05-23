using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsByCategory
{
    public class GetPartsByCategoryQueryHandler : IRequestHandler<GetPartsByCategoryQueryRequest, GetPartsByCategoryQueryResponse>
    {
        private readonly IPartReadRepository _repository;

        public GetPartsByCategoryQueryHandler(IPartReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetPartsByCategoryQueryResponse> Handle(GetPartsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
          var parts= _repository.GetWhere(x => x.CategoryId == request.Id).ToList();
            var resp = new GetPartsByCategoryQueryResponse()
            {
                Parts=parts
            };
            return Task.FromResult(resp);
        }
    }
}
