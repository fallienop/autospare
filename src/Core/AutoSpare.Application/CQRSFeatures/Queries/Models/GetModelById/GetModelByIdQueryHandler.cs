using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Models.GetModelById
{
    public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQueryRequest, GetModelByIdQueryResponse>
    {
        private readonly IModelReadRepository _repository;

        public GetModelByIdQueryHandler(IModelReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetModelByIdQueryResponse> Handle(GetModelByIdQueryRequest request, CancellationToken cancellationToken)
        {
           var model= await _repository.GetByIdAsync(request.Id,false);
            return new() {Model=model };
        }
    }
}
