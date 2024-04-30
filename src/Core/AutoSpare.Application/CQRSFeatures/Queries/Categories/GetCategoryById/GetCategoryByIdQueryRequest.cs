using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryrResponse>
    {
        public string Id { get; set; }
    }
}
