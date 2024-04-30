using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsByModel
{
    public class GetPartsByModelQueryHandle : IRequestHandler<GetPartsByModelQueryRequest, GetPartsByModelQueryResponse>
    {
        private readonly IPartReadRepository _repository;

        public GetPartsByModelQueryHandle(IPartReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetPartsByModelQueryResponse> Handle(GetPartsByModelQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = _repository.GetWhere(x => x.ModelId == Guid.Parse(request.ModelId),false);
            var resp = new GetPartsByModelQueryResponse() {
                Parts= parts
            };
            return Task.FromResult(resp);

        }
    }
}
