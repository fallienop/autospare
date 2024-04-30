using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryrResponse>
    {
        private readonly ICategoryReadRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryrResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var resp = await _repository.GetByIdAsync(request.Id, false);
            return new()
            {
                Category = resp
            };
        }
    }
}
