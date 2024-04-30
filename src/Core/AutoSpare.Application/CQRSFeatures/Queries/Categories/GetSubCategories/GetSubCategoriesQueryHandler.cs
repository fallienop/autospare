using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Categories.GetSubCategories
{
    public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQueryRequest, GetSubCategoriesQueryResponse>
    {
        private readonly ICategoryReadRepository _repository;

        public GetSubCategoriesQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetSubCategoriesQueryResponse> Handle(GetSubCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _repository.GetWhere(x => x.ParentCategoryId == Guid.Parse(request.Id), false);
            var resp= new GetSubCategoriesQueryResponse() { 
            Categories = categories
            };
            return Task.FromResult(resp);
        }
    }
}
