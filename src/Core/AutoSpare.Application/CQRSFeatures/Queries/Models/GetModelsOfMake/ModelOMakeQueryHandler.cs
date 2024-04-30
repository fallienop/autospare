using AutoSpare.Application.Repositories.ProductRepos.ModelRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Models.GetModelsOfMake
{
    public class ModelOMakeQueryHandler : IRequestHandler<ModelOMakeQueryRequest, ModelOMakeQueryResponse>
    {
        private readonly IModelReadRepository _repository;

        public ModelOMakeQueryHandler(IModelReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ModelOMakeQueryResponse> Handle(ModelOMakeQueryRequest request, CancellationToken cancellationToken)
        {
            var models = _repository.GetWhere(x=>x.MakeId==Guid.Parse(request.Id), false);
            return new() { Models = models };
        }
    }
}
