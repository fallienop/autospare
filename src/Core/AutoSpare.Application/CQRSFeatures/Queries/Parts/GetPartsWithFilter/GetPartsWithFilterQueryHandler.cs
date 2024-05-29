using AutoSpare.Application.Repositories.ProductRepos.PartRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPartsWithFilter
{
    public class GetPartsWithFilterQueryHandler : IRequestHandler<GetPartsWithFilterQueryRequest, GetPartsWithFilterQueryResponse>
    {
        private readonly IPartReadRepository _repository;

        public GetPartsWithFilterQueryHandler(IPartReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetPartsWithFilterQueryResponse> Handle(GetPartsWithFilterQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.Table.AsQueryable();

            if (!string.IsNullOrEmpty(request.ModelId))
            {
                query = query.Where(p => p.ModelId.ToString() == request.ModelId);
            }

            if (request.BrandId != null && request.BrandId.Any())
            {
                query = query.Where(p => p.BrandId.HasValue && request.BrandId.Contains(p.BrandId.Value));
            }


            if (request.CompanyId != null && request.CompanyId.Any())
            {
                query = query.Where(p => p.CompanyId.HasValue && request.CompanyId.Contains(p.CompanyId.Value));
            }

            if (request.MinimumPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinimumPrice.Value);
            }

            if (request.MaximumPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaximumPrice.Value);
            }

            if (!string.IsNullOrEmpty(request.CategoryId))
            {
                query = query.Where(p => p.Category.Id.ToString() == request.CategoryId);
            }

            if (!string.IsNullOrEmpty(request.DetailCode))
            {
                query = query.Where(p => p.Code == request.DetailCode);
            }

            if (request.Year.HasValue)
            {
                query = query.Where(p => p.EndYear >= request.Year.Value);
                query = query.Where(p => p.StartYear <= request.Year.Value);
            }
            var parts = await query.ToListAsync();
            return new() { Parts = parts };
        }
    }
}
