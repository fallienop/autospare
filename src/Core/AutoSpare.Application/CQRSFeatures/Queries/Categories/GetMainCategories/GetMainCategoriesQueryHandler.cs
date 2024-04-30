using AutoSpare.Application.Repositories.CategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Categories.GetMainCategories
{
    public class GetMainCategoriesQueryHandler : IRequestHandler<GetMainCategoriesQueryRequest, GetMainCategoriesQueryResponse>
    {
        private readonly ICategoryReadRepository _repository;

        public GetMainCategoriesQueryHandler(ICategoryReadRepository repository)
        {
            _repository = repository;
        }

        public Task<GetMainCategoriesQueryResponse> Handle(GetMainCategoriesQueryRequest request, CancellationToken cancellationToken)
        {

            var categories = _repository.GetWhere(x => x.ParentCategoryId == null, false);
             var resp= new GetMainCategoriesQueryResponse()
             {
                 Categories = categories
             };
           
            return Task.FromResult(resp);
  
 
        }
    }
}
