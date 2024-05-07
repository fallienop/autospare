using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPart
{
    public class GetPartQueryHandler : IRequestHandler<GetPartQueryRequest, GetPartQueryResponse>
    {
        private readonly IPartReadRepository _repository;

        public GetPartQueryHandler(IPartReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPartQueryResponse> Handle(GetPartQueryRequest request, CancellationToken cancellationToken)
        {
       var part = await _repository.GetByIdAsync(request.Id,false);
            return new() { Part= part };
        }
    }
}
