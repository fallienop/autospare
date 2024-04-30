using AutoSpare.Application.Repositories.BrandRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Brands.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQueryRequest, GetBrandByIdQueryResponse>
    {
        private readonly IBrandReadRepository _repository;

        public GetBrandByIdQueryHandler(IBrandReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResponse> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByIdAsync(request.Id, false);

            return new()
            {
                Brand = brand
            };
        }
    }
}
