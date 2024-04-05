using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Models.GetModelById
{
    public class GetModelByIdQueryRequest : IRequest<GetModelByIdQueryResponse>
    {
        public string Id { get; set; } = null!;

    }
}
