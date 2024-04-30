using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetAllParts
{
    public class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQueryRequest, GetAllPartsQueryResponse>
    {
        private readonly IPartReadRepository _repository;

        public GetAllPartsQueryHandler(IPartReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetAllPartsQueryResponse> Handle(GetAllPartsQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = _repository.GetAll(false);
            var resp= new GetAllPartsQueryResponse()
            {
                Parts = parts
            };
           return Task.FromResult(resp);
        }
    }
}
