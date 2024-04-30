using AutoSpare.Application.Repositories.BrandRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Brands.GetBrands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQueryRequest, GetBrandsQueryResponse>
    {
        private readonly IBrandReadRepository _repository;

        public GetBrandsQueryHandler(IBrandReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetBrandsQueryResponse> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands=_repository.GetAll(false);
            var resp = new GetBrandsQueryResponse()
            {
                Brands = brands
            };
            return Task.FromResult(resp);

        }
    }
}
