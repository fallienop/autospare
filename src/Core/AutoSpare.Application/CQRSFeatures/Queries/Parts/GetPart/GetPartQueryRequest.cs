using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSpare.Application.CQRSFeatures.Queries.Parts.GetPart
{
    public class GetPartQueryRequest : IRequest<GetPartQueryResponse>
    {
        public string Id { get; set; }
    }
}
