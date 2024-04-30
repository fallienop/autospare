using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Categories.GetSubCategories
{
    public class GetSubCategoriesQueryRequest : IRequest<GetSubCategoriesQueryResponse>
    {
        public string Id { get; set; }

    }
}
